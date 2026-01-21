using UnityEngine;
using TMPro;

public class PlayerRotation2D : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI angleDisplay;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Lấy vị trí chuột trên màn hình → chuyển sang world position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorldPos = ray.origin + ray.direction * distance;

            // Tính hướng từ player đến chuột
            Vector3 direction = (mouseWorldPos - transform.position).normalized;

            float angle = Vector2.SignedAngle(
                Vector2.right,  // Hướng tham chiếu (phải = 0°)
                new Vector2(direction.x, direction.z)
            );

            // Xoay nhân vật
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Hiển thị góc trên UI
            if (angleDisplay != null)
            {
                angleDisplay.text = $"Angle: {angle:F1}°\nDir: {direction}";
            }

            // Debug gizmos
            Debug.Log($"Signed Angle: {angle}° | Direction: {direction}");
        }
    }

    // Vẽ debug
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
    }
}