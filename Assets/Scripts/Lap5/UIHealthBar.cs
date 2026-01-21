using UnityEngine;
using TMPro;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    private PlayerHealth playerHealth;

    // ==================== SUBSCRIBE ====================
    void Start()
    {
        // Tìm PlayerHealth trong scene
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth != null)
        {

            playerHealth.OnHealthChanged += UpdateHealthDisplay;

            Debug.Log("[UI] Subscribed to OnHealthChanged event");
        }
        else
        {
            Debug.LogError("[UI] PlayerHealth not found in scene!");
        }
    }

    private void UpdateHealthDisplay(float newHealth, float maxHealth)
    {
        // Cập nhật text UI
        healthText.text = $"Health: {newHealth:F0}/{maxHealth:F0}";

        // Đổi màu dựa trên % máu
        float healthPercent = newHealth / maxHealth;
        if (healthPercent > 0.5f)
        {
            healthText.color = Color.green;
        }
        else if (healthPercent > 0.25f)
        {
            healthText.color = Color.yellow;
        }
        else
        {
            healthText.color = Color.red;
        }

        Debug.Log($"[UI] Health updated: {newHealth:F0}/{maxHealth:F0}");
    }
    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthDisplay;
            Debug.Log("[UI] Unsubscribed from OnHealthChanged event");
        }
    }
}