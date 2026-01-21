using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    public delegate void HealthChangedEvent(float newHealth, float maxHealth);

    public event HealthChangedEvent OnHealthChanged;

    // Event khi chết
    public delegate void PlayerDeadEvent();
    public event PlayerDeadEvent OnPlayerDead;

    // ==================== INITIALIZATION ====================
    void Start()
    {
        currentHealth = maxHealth;

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        Debug.Log("PlayerHealth initialized. Current Health: " + currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log($"[PLAYER] Took {damage} damage! Health: {currentHealth}/{maxHealth}");

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        // Kiểm tra game over
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("[PLAYER] PLAYER IS DEAD!");

            // Phát sự kiện chết
            OnPlayerDead?.Invoke();
        }
    }

    // Hàm getter (tuỳ chọn)
    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
}