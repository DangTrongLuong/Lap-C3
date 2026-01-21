using UnityEngine;

public class TurretRotationSmooth : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed = 2f;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not assigned!");
            return;
        }

        // Tính vector hướng từ turret đến target
        Vector3 directionToTarget = target.position - transform.position;

        // Kiểm tra direction hợp lệ
        if (directionToTarget.magnitude > 0.001f)
        {
            // Tính rotation mục tiêu
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Xoay MƯỢT từ rotation hiện tại đến target rotation
            // Slerp: nội suy tuyến tính trên mặt cầu (Spherical Linear Interpolation)
            transform.rotation = Quaternion.Slerp(
                transform.rotation,           // Rotation hiện tại
                targetRotation,               // Rotation mục tiêu
                rotationSpeed * Time.deltaTime // Tốc độ xoay
            );

            Debug.Log($"[SMOOTH] Target Pos: {target.position}, Direction: {directionToTarget.normalized}, Rotation Y: {transform.eulerAngles.y}");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, target.position);
            Gizmos.DrawSphere(target.position, 0.2f);
        }
    }
}