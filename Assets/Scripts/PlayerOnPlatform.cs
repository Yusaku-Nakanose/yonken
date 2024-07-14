using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    private Transform originalParent;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            originalParent = transform.parent;
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = originalParent;
        }
    }
}