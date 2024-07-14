using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // GameObject�^��ϐ�target�Ő錾���܂��B
    public GameObject target;

    // ��{�ݒ�
    public float normalSpeed = 0.05f; // �ʏ�̈ړ����x
    public float rushSpeed = 0.2f;    // �ːi���x
    public float rushDistance = 5.0f; // �ːi���J�n���鋗��
    public float rushDuration = 2.0f; // �ːi�̎�������

    private bool isRushing = false;   // �ːi�����ǂ����̃t���O
    private float rushTimer = 0.0f;   // �ːi�̃^�C�}�[
    private Vector3 rushDirection;    // �ːi�̕���

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
        // �^�[�Q�b�g�܂ł̋������v�Z���܂�
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        // �^�[�Q�b�g�̕����������܂�
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
        lookRotation.z = 0;
        lookRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        // �^�[�Q�b�g�ɋ߂Â�����ːi���J�n���܂�
        if (distanceToTarget < rushDistance)
        {
            StartRushing();
        }
        else
        {
            // �ʏ�̑��x�ňړ����܂�
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
            // �ːi�����Ɉړ����܂�
            Vector3 movement = rushDirection * rushSpeed;
            transform.Translate(movement, Space.World);
            rushTimer -= Time.deltaTime;
        }
        else
        {
            // �ːi���I��������ʏ탂�[�h�ɖ߂�܂�
            isRushing = false;
        }
    }
}
