
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    private Vector3 pos;

    public void MoveStart()
    {
        StartCoroutine("FloorMove");
    }

    IEnumerator FloorMove()
    {
        while (pos.y < 3.0f)
        {
            pos = transform.position;
            transform.Translate(0, 0.02f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
