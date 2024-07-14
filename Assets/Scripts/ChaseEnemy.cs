using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // GameObject型を変数targetで宣言します。
    public GameObject target;

    // 基本設定
    public float normalSpeed = 0.05f; // 通常の移動速度
    public float rushSpeed = 0.2f;    // 突進速度
    public float rushDistance = 5.0f; // 突進を開始する距離
    public float rushDuration = 2.0f; // 突進の持続時間

    private bool isRushing = false;   // 突進中かどうかのフラグ
    private float rushTimer = 0.0f;   // 突進のタイマー
    private Vector3 rushDirection;    // 突進の方向

    // Update is called once per frame
    void Update()
    {
        if (isRushing)
        {
            Rush();
        }
        else
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // ターゲットまでの距離を計算します
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        // ターゲットの方向を向きます
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
        lookRotation.z = 0;
        lookRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        // ターゲットに近づいたら突進を開始します
        if (distanceToTarget < rushDistance)
        {
            StartRushing();
        }
        else
        {
            // 通常の速度で移動します
            Vector3 movement = transform.forward * normalSpeed;
            transform.Translate(movement, Space.World);
        }
    }

    void StartRushing()
    {
        isRushing = true;
        rushTimer = rushDuration;
        rushDirection = transform.forward;
    }

    void Rush()
    {
        if (rushTimer > 0)
        {
            // 突進方向に移動します
            Vector3 movement = rushDirection * rushSpeed;
            transform.Translate(movement, Space.World);
            rushTimer -= Time.deltaTime;
        }
        else
        {
            // 突進が終了したら通常モードに戻ります
            isRushing = false;
        }
    }
}
