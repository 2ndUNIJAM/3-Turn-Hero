using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    private const float TURN_DISTANCE = 1f;
    private const float MOVE_MIN_DISTANCE = 3f;
    private const float MOVE_MAX_DISTANCE = 6f;

    protected float recognizeDistance;
    protected bool isGotoRight;
    protected bool isChasing;

    protected Coroutine patrolCo;

    protected virtual bool RecognizePlayer()
    {
        float distance = Vector2.Distance(this.transform.position, PlayerManager.Instance.transform.position);
        if (distance < recognizeDistance)
            return true;
        else
            return false;
    }

    protected virtual void GotoPlayer()
    {
        if (isGotoRight)
        {
            Move(Vector3.right, Stat.MoveSpeed);
            if (transform.position.x >= PlayerManager.Instance.transform.position.x + TURN_DISTANCE)
                isGotoRight = false;
        }
        else
        {
            Move(Vector3.left, Stat.MoveSpeed);
            if (transform.position.x + TURN_DISTANCE <= PlayerManager.Instance.transform.position.x)
                isGotoRight = true;
        }
    }

    protected virtual void StopPatrol() => StopCoroutine(patrolCo);

    protected IEnumerator Patrol()
    {
        float moveDistance = Random.Range(MOVE_MIN_DISTANCE, MOVE_MAX_DISTANCE);
        float moveDir = (RandomManager.GetFlag(0.5f)) ? 1f : -1f;

        Debug.Log($"{Data.Name} : Patrol Start");

        while (Mathf.Abs(moveDistance) > 0.01f)
        {
            float speed = Stat.MoveSpeed * 0.5f;
            Move(Vector3.right * moveDir, speed);
            moveDistance -= speed * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(Random.Range(0.5f, 2f));

        patrolCo = StartCoroutine(Patrol());
    }

    private void Move(Vector3 dir, float moveSpeed)
    {
        this.transform.position += dir * moveSpeed * Time.deltaTime;
        this.transform.localScale = (dir.x < 0f) ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
    }
}
