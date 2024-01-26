using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TempMonster : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        recognizeDistance = 2f;

        patrolCo = StartCoroutine(Patrol());
    }

    private void FixedUpdate()
    {
        if (isChasing)
        {
            if (patrolCo != null)
                StopPatrol();
            GotoPlayer();
        }
        else
        {
            isChasing = RecognizePlayer();

            if (patrolCo == null)
                patrolCo = StartCoroutine(Patrol());
        }
    }
}
