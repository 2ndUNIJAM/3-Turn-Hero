using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Goblin : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        recognizeDis = 5f;
        outofDis = 10f;
        attackDis = 1f;
        knockBackPower = 3f;
        hpbarHeight = 1f;
        attackTiming = 0.5f;
        upPos = Vector3.up * 1.25f;

        isCanAttack = true;
    }

    private void FixedUpdate()
    {
        if (isCanAttack && CheckAttack())
            Attack();

        if (isAttacking || isFaint)
            return; // ���� �߿� �Ʒ� ����� �������� ����

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
