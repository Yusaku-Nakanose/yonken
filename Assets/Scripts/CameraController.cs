using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target = null;

    void Start()
    {

    }

    void Update()
    {
        Vector3 position = target.transform.position;
        Quaternion rotation = target.transform.rotation;
        position.y += 3f;
        position.z -= 4f;
        rotation.x = 0.1f;
        transform.position = position;
        transform.rotation = rotation;
    }
}
