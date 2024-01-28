using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Golem : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        recognizeDis = 3f;
        outofDis = 5f;
        attackDis = 1.25f;
        knockBackPower = 0f;
        hpbarHeight = 2.25f;
        attackTiming = 0.75f;
        upPos = Vector3.up * 2.5f;

        isCanAttack = true;
    }

    private void FixedUpdate()
    {
        if (isCanAttack && CheckAttack())
            Attack();

        if (isAttacking || isFaint)
            return;

        if (isChasing)
        {
            if (patrolCo != null)
                StopPatrol();

            GotoPlayer();

            if (CheckOutOfRange())
            {
                isChasing = false;
                patrolCo = StartCoroutine(Patrol());
            }
        }
        else
        {
            if (patrolCo == null)
                patrolCo = StartCoroutine(Patrol());

            if (RecognizePlayer())
                isChasing = true;
        }
    }
}


