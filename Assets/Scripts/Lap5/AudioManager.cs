using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio clips (tuỳ chọn - nếu không có thì skip)
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip deathSound;

    private AudioSource audioSource;
    private PlayerHealth playerHealth;

    // ==================== SUBSCRIBE ====================
    void Start()
    {
        // Lấy AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Tìm PlayerHealth
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth != null)
        {
            
            playerHealth.OnHealthChanged += PlayDamageSound;

            
            playerHealth.OnPlayerDead += PlayDeathSound;

            Debug.Log("[AUDIO] Subscribed to health events");
        }
        else
        {
            Debug.LogError("[AUDIO] PlayerHealth not found!");
        }
    }

    // ==================== CALLBACK 1: DAMAGE SOUND ====================
    private void PlayDamageSound(float newHealth, float maxHealth)
    {
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
            Debug.Log("[AUDIO] Playing damage sound!");
        }
        else
        {
            // Nếu không có audio clip, chỉ log thôi
            Debug.Log("[AUDIO] Damage sound not configured (OK for testing)");
        }
    }

    // ==================== CALLBACK 2: DEATH SOUND ====================
    private void PlayDeathSound()
    {
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
            Debug.Log("[AUDIO] Playing death sound!");
        }
        else
        {
            Debug.Log("[AUDIO] Death sound not configured (OK for testing)");
        }
    }

    // ==================== UNSUBSCRIBE ====================
    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= PlayDamageSound;
            playerHealth.OnPlayerDead -= PlayDeathSound;
            Debug.Log("[AUDIO] Unsubscribed from health events");
        }
    }
}