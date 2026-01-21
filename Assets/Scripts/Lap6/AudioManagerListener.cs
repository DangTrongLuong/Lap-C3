using UnityEngine;

public class AudioManagerListener : MonoBehaviour
{
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip deathSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ==================== CALLBACK 1: DAMAGE SOUND ====================
    public void OnHealthChanged(float currentHealth, float maxHealth)
    {
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
            Debug.Log("[AUDIO] Playing damage sound!");
        }
        else
        {
            Debug.Log("[AUDIO] Damage sound not configured");
        }
    }

    // ==================== CALLBACK 2: DEATH SOUND ====================
    public void OnPlayerDead()
    {
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
            Debug.Log("[AUDIO] Playing death sound!");
        }
        else
        {
            Debug.Log("[AUDIO] Death sound not configured");
        }
    }
}