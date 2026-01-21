using UnityEngine;

public class PlayerInputUnityEvent : MonoBehaviour
{
    private PlayerHealthUnityEvent playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealthUnityEvent>();

        if (playerHealth == null)
        {
            Debug.LogError("[INPUT] PlayerHealth not found!");
        }
    }

    void Update()
    {
        // Nhấn H để nhận 10 damage
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("[INPUT] H pressed!");
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10f);
            }
        }

        // Nhấn Space để nhận 25 damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("[INPUT] Space pressed!");
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(25f);
            }
        }

        // Nhấn K để nhận 100 damage (chết)
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("[INPUT] K pressed!");
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(100f);
            }
        }
    }
}