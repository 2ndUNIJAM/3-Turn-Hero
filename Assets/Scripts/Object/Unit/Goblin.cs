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
            return; // 공격 중엔 아래 기능을 수행하지 않음

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
