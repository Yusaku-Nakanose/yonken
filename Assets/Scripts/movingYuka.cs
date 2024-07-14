using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointB;
    private Vector3 pointA;
    public float speed = 2.0f;

    public Vector3 rotationPointB;
    private Quaternion rotationPointA;

    void Start()
    {
        pointA = transform.position;
        rotationPointA = transform.rotation;
    }

    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
        transform.rotation = Quaternion.Lerp(rotationPointA, Quaternion.Euler(rotationPointB), time);
    }
}
