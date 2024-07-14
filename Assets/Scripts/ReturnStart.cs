using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnStart : MonoBehaviour
{
    //スタート位置を示すオブジェクトを格納する変数
    public GameObject start = null;
    //スタート位置を記憶するための変数
    public Vector3 start_position;
    // Start is called before the first frame update
    void Start()
    {
        //スタート位置を記憶
        start_position = start.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのy座標が一定を下回った場合、スタート位置に戻す
        if(transform.position.y < -10)
        {
            transform.position = start_position;
        }
    }
}
