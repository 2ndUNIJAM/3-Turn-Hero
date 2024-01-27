using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ogre : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        recognizeDis = 3f;
        outofDis = 8f;
        attackDis = 1.5f;
        knockBackPower = 0.5f;
        hpbarHeight = 1.5f;
        attackTiming = 0.7f;
        upPos = Vector3.up * 1.75f;

        isCanAttack = true;
    }

    private void FixedUpdate()
    {
        if (isCanAttack && CheckAttack())
            Attack();

        if (isAttacking || isFaint)
            return; // �Ʒ� ����� �������� ����

        if (isChasing)
        {
            if (patrolCo != null)
                StopPatrol(); // ���� ����

            // ����
            GotoPlayer();

            // ���� ����� ���� ����
            if (CheckOutOfRange())
            {
                isChasing = false;
                patrolCo = StartCoroutine(Patrol());
            }
        }
        else
        {
            // ����
            if (patrolCo == null)
                patrolCo = StartCoroutine(Patrol());

            // �÷��̾� ���� �� ���� ����
            if (RecognizePlayer())
                isChasing = true;
        }
    }
}
