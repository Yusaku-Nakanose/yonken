using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.SetBool("Jump", false);
        Vector3 vector = new Vector3(0, 0, v);
        vector = transform.TransformDirection(vector) * 5f;
        transform.localPosition += vector * Time.fixedDeltaTime;
        transform.Rotate(0, h, 0);

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up);
            anim.SetBool("Jump", true);
        }
    }
}
