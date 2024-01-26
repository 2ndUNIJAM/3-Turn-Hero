using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TempMonster : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        recognizeDistance = 3f;
        outofDistance = 6f;

        patrolCo = StartCoroutine(Patrol());
    }

    private void FixedUpdate()
    {
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
