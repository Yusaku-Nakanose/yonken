using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    public GameObject upFloor;
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Area")
        {
            upFloor.GetComponent<MoveUp>().MoveStart();
        }
    }
}
