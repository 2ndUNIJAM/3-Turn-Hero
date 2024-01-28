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
            return; // 아래 기능을 수행하지 않음

        if (isChasing)
        {
            if (patrolCo != null)
                StopPatrol(); // 순찰 종료

            // 추적
            GotoPlayer();

            // 범위 벗어나면 순찰 시작
            if (CheckOutOfRange())
            {
                isChasing = false;
                patrolCo = StartCoroutine(Patrol());
            }
        }
        else
        {
            // 순찰
            if (patrolCo == null)
                patrolCo = StartCoroutine(Patrol());

            // 플레이어 감지 시 추적 시작
            if (RecognizePlayer())
                isChasing = true;
        }
    }
}
