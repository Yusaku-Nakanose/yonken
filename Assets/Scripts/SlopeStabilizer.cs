using UnityEngine;

public class UnityChanCollisionResolver : MonoBehaviour
{
    [SerializeField] private float uprightStrength = 10f;
    [SerializeField] private float rotationDamping = 0.95f; // 回転の減衰係数
    [SerializeField] private float maxTiltAngle = 45f; // 最大傾斜角度
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private float collisionOffset = 0.1f;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        if (rb == null || capsuleCollider == null)
        {
            Debug.LogError("RigidbodyまたはCapsuleColliderが見つかりません。");
            enabled = false;
        }
    }

    private void FixedUpdate()
    {
        ResolveCollisions();
        MaintainUpright();
        LimitTiltAngle();
        DampRotation();
    }

    private void ResolveCollisions()
    {
        Vector3 bottom = transform.position + capsuleCollider.center - Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
        Vector3 top = transform.position + capsuleCollider.center + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);

        RaycastHit hit;
        if (Physics.CapsuleCast(bottom, top, capsuleCollider.radius, rb.velocity.normalized, out hit, rb.velocity.magnitude * Time.fixedDeltaTime + collisionOffset, collisionLayer))
        {
            Vector3 reflectionVector = Vector3.Reflect(rb.velocity, hit.normal);
            rb.velocity = reflectionVector.normalized * rb.velocity.magnitude;
            rb.MovePosition(hit.point + hit.normal * collisionOffset);
        }
    }

    private void MaintainUpright()
    {
        Vector3 upDirection = transform.up;
        Vector3 targetUpDirection = Vector3.up;

        Vector3 torque = Vector3.Cross(upDirection, targetUpDirection) * uprightStrength;
        rb.AddTorque(torque);
    }

    private void LimitTiltAngle()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float tiltX = currentRotation.x > 180 ? currentRotation.x - 360 : currentRotation.x;
        float tiltZ = currentRotation.z > 180 ? currentRotation.z - 360 : currentRotation.z;

        tiltX = Mathf.Clamp(tiltX, -maxTiltAngle, maxTiltAngle);
        tiltZ = Mathf.Clamp(tiltZ, -maxTiltAngle, maxTiltAngle);

        transform.rotation = Quaternion.Euler(tiltX, currentRotation.y, tiltZ);
    }

    private void DampRotation()
    {
        rb.angularVelocity *= rotationDamping;
    }
}