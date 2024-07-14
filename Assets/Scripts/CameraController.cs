using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target = null;
    public float height = 3f;
    public float distance = 4f;

    void LateUpdate()
    {
        if (target != null)
        {
            // ターゲットの位置と回転を取得
            Vector3 targetPosition = target.transform.position;
            Quaternion targetRotation = target.transform.rotation;

            // カメラの位置を計算
            Vector3 position = targetPosition - (targetRotation * Vector3.forward * distance);
            position.y = targetPosition.y + height;

            // カメラの位置と回転を適用
            transform.position = position;
            transform.LookAt(targetPosition + Vector3.up * height / 2);
        }
    }
}