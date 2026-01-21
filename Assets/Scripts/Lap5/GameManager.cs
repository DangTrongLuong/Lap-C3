using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;      // Panel chứa game over UI
    [SerializeField] private UnityEngine.UI.Button playAgainButton;  // Button play again
    [SerializeField] private TextMeshProUGUI healthText;    // Health text UI
    [SerializeField] private UnityEngine.UI.Button damageButton;     // Damage button

    private PlayerHealth playerHealth;
    private bool isGameOver = false;

    // ==================== SUBSCRIBE ====================
    void Start()
    {
        // Tìm PlayerHealth
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth != null)
        {
            // Đăng ký event chết
            playerHealth.OnPlayerDead += OnGameOver;

            Debug.Log("[GAME] Subscribed to OnPlayerDead event");
        }
        else
        {
            Debug.LogError("[GAME] PlayerHealth not found!");
        }

        // Ẩn game over panel lúc đầu
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
            Debug.Log("[GAME] Game Over Panel hidden initially");
        }

        // Gắn button listener
        if (playAgainButton != null)
        {
            playAgainButton.onClick.AddListener(PlayAgain);
            Debug.Log("[GAME] Play Again button listener added");
        }

        // Hiển thị health text và damage button lúc đầu
        if (healthText != null)
        {
            healthText.gameObject.SetActive(true);
        }
        if (damageButton != null)
        {
            damageButton.gameObject.SetActive(true);
        }
    }

    // ==================== CALLBACK: GAME OVER ====================
    private void OnGameOver()
    {
        isGameOver = true;

        Debug.Log("[GAME] GAME OVER!");

        // Ẩn Health Text
        if (healthText != null)
        {
            healthText.gameObject.SetActive(false);
            Debug.Log("[GAME] Health Text hidden");
        }

        // Ẩn Damage Button
        if (damageButton != null)
        {
            damageButton.gameObject.SetActive(false);
            Debug.Log("[GAME] Damage Button hidden");
        }

        // Hiển thị game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("[GAME] Game Over Panel shown");
        }

        // Dừng game
        Time.timeScale = 0f;
        Debug.Log("[GAME] Game paused (Time.timeScale = 0)");
    }

    // ==================== CALLBACK: PLAY AGAIN ====================
    private void PlayAgain()
    {
        Debug.Log("[GAME] Play Again button clicked!");

        // Resume game
        Time.timeScale = 1f;
        Debug.Log("[GAME] Game resumed (Time.timeScale = 1)");

        // Reload scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    // ==================== UNSUBSCRIBE ====================
    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnPlayerDead -= OnGameOver;
            Debug.Log("[GAME] Unsubscribed from OnPlayerDead event");
        }
    }
}