using UnityEngine;
using TMPro;

public class GameManagerListener : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private UnityEngine.UI.Button playAgainButton;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private UnityEngine.UI.Button damageButton;

    void Start()
    {
        // Ẩn panel lúc đầu
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Gắn button listener
        if (playAgainButton != null)
        {
            playAgainButton.onClick.AddListener(PlayAgain);
        }
    }

    // ==================== CALLBACK: GAME OVER ====================
    public void OnPlayerDead()
    {
        Debug.Log("[GAME] GAME OVER!");

        // Ẩn Health Text
        if (healthText != null)
        {
            healthText.gameObject.SetActive(false);
        }

        // Ẩn Damage Button
        if (damageButton != null)
        {
            damageButton.gameObject.SetActive(false);
        }

        // Hiển thị Game Over Panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("[GAME] Game Over Panel shown");
        }

        // Dừng game
        Time.timeScale = 0f;
    }

    // ==================== PLAY AGAIN ====================
    private void PlayAgain()
    {
        Debug.Log("[GAME] Play Again clicked!");

        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}