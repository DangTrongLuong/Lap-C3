using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        // Lấy input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        if (movement.magnitude > 0)
        {
            movement.Normalize();
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }

    // Vẽ Gizmos để debug hướng di chuyển
    private void OnDrawGizmosSelected()
    {
        // Lấy direction hiện tại
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

        // Vẽ gizmo mũi tên
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + direction * 2);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + direction * 2, 0.2f);

        Debug.Log($"Movement Direction: {direction.normalized}, Magnitude: {direction.magnitude}");
    }
}