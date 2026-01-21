using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthUnityEvent : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    // ==================== UNITYEVENT DEFINITION ====================
    // UnityEvent: Có thể binding trong Inspector
    // Tham số: float newHealth, float maxHealth
    [SerializeField] public UnityEvent<float, float> onHealthChanged = new UnityEvent<float, float>();

    // Event khi chết
    [SerializeField] public UnityEvent onPlayerDead = new UnityEvent();

    // ==================== INITIALIZATION ====================
    void Start()
    {
        currentHealth = maxHealth;

        // Phát sự kiện lần đầu
        onHealthChanged.Invoke(currentHealth, maxHealth);

        Debug.Log("[HEALTH] PlayerHealth initialized. Current Health: " + currentHealth);
    }

    // ==================== PUBLIC METHOD ====================
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log($"[HEALTH] Took {damage} damage! Health: {currentHealth}/{maxHealth}");

        // Phát sự kiện OnHealthChanged
        // Tất cả callback binding sẽ được gọi
        onHealthChanged.Invoke(currentHealth, maxHealth);

        // Kiểm tra game over
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("[HEALTH] PLAYER IS DEAD!");

            // Phát sự kiện OnPlayerDead
            onPlayerDead.Invoke();
        }
    }

    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
}