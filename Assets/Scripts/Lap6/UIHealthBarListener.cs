using UnityEngine;
using TMPro;

public class UIHealthBarListener : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    // ==================== CALLBACK ====================
    // Hàm này sẽ được gọi khi UnityEvent phát
    public void OnHealthChanged(float currentHealth, float maxHealth)
    {
        healthText.text = $"Health: {currentHealth:F0}/{maxHealth:F0}";

        // Đổi màu dựa trên % máu
        float healthPercent = currentHealth / maxHealth;
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

        Debug.Log($"[UI] Health updated: {currentHealth:F0}/{maxHealth:F0}");
    }
}