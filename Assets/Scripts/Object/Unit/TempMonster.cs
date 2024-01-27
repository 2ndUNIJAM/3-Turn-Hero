using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TempMonster : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        recognizeDis = 4f;
        outofDis = 8f;
        attackDis = 0.5f;
        knockBackPower = 1.5f;
        hpbarHeight = 1f;
        upPos = Vector3.up * 1.25f;

        isCanAttack = true;
    }

    private void FixedUpdate()
    {
        if (isCanAttack && CheckAttack())
            Attack();

        if (isAttacking)
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
