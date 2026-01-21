using UnityEngine;

public class TurretRotationFast : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is NOT assigned!");
            return;
        }

        // Tính vector hướng từ turret đến target
        Vector3 directionToTarget = target.position - transform.position;

        // Kiểm tra direction hợp lệ
        if (directionToTarget.magnitude > 0.001f)
        {
            // Xoay turret nhìn vào target
            // LookRotation: làm cho forward (xanh) hướng vào direction
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Áp dụng rotation ngay lập tức
            transform.rotation = targetRotation;

            Debug.Log($"[FAST] Target Pos: {target.position}, Direction: {directionToTarget.normalized}, Rotation Y: {transform.eulerAngles.y}");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);
            Gizmos.DrawSphere(target.position, 0.2f);
        }
    }
}