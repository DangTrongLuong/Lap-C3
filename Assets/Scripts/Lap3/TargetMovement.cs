using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        // Lấy input WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Tạo vector di chuyển
        Vector3 movement = new Vector3(moveX, 0, moveZ);

        // Normalize để tránh chạy chéo nhanh
        if (movement.magnitude > 0)
        {
            movement.Normalize();
        }

        // Cập nhật vị trí
        transform.Translate(movement * speed * Time.deltaTime);

        Debug.Log($"Target Position: {transform.position}");
    }
}