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
