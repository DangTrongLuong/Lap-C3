using UnityEngine;

public class OrbitRotation : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed = 20f;
    public float followSpeed = 5f;

    void Update()
    {
        if (target == null) return;

        // Di chuyển nhóm đến vị trí target
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);

        // Xoay quanh target
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
