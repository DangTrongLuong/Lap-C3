using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("[INPUT] PlayerHealth component not found on this GameObject!");
        }
        else
        {
            Debug.Log("[INPUT] PlayerHealth found successfully!");
        }
    }

    void Update()
    {
        // Nhấn H để nhận 10 damage
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("[INPUT] H key pressed!");

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10f);
                Debug.Log("[INPUT] TakeDamage(10) called successfully!");
            }
            else
            {
                Debug.LogError("[INPUT] PlayerHealth is NULL!");
            }
        }

        // Nhấn Space để nhận 25 damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("[INPUT] Space key pressed!");

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(25f);
                Debug.Log("[INPUT] TakeDamage(25) called successfully!");
            }
            else
            {
                Debug.LogError("[INPUT] PlayerHealth is NULL!");
            }
        }

        // Nhấn K để nhận 100 damage (chết)
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("[INPUT] K key pressed!");

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(100f);
                Debug.Log("[INPUT] TakeDamage(100) called successfully!");
            }
            else
            {
                Debug.LogError("[INPUT] PlayerHealth is NULL!");
            }
        }
    }
}