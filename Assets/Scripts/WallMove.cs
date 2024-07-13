using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    int counter = 0;
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = new Vector3(speed, 0, 0);
        transform.Translate(p);
        counter++;
        if(counter == 100)
        {
            counter = 0;
            speed *= -1;
        }
    }
}
