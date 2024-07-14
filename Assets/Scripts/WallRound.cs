using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRound : MonoBehaviour
{
    public float roundspeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var v = new Vector3(0, roundspeed, 0);
        transform.Rotate(v);
    }
}
