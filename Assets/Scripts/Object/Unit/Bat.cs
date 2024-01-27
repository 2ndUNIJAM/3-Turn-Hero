using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bat : Monster
{
    private const float TURN_DISTANCE = 1.5f;

    private Vector3 rushVec;

    // Start is called before the first frame update
    void Start()
    {
        recognizeDis = 5f;
        outofDis = 8f;
        attackDis = 0.5f;
        knockBackPower = 3f;
        hpbarHeight = 0.75f;
        upPos = Vector3.up;

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

    protected override void GotoPlayer()
    {
        if (isDead || isFaint)
            return; // �װų� ������ ���

        if (isGotoRight)
        {
            //Move(Vector3.right, Stat.MoveSpeed);
            if (transform.position.x >= PlayerManager.Instance.transform.position.x + TURN_DISTANCE)
                isGotoRight = false;
        }
        else
        {
            //Move(Vector3.left, Stat.MoveSpeed);
            if (transform.position.x + TURN_DISTANCE <= PlayerManager.Instance.transform.position.x)
                isGotoRight = true;
        }
    }

    protected override bool CheckAttack()
        => Physics2D.CircleCast(transform.position, attackDis, Vector2.zero, 0f, 128);

    protected override void Attack()
    {
        base.Attack();

        StartCoroutine(Rush());
    }

    IEnumerator Rush()
    {
        Vector3 startDir = this.transform.up - this.transform.right;
        Vector3 gap;
        rushVec = PlayerManager.Instance.transform.position - this.transform.position;

        float angle = Vector3.SignedAngle(transform.up, rushVec - startDir, -transform.forward);
        while (angle < 1f)
        {
            gap = startDir + rushVec;
            //transform.rotation = Quaternion.Euler(Quaternion. + gap);
            angle = Vector3.SignedAngle(transform.up, rushVec - startDir, -transform.forward);
        }

        this.transform.rotation = Quaternion.Euler(rushVec);

        yield return new WaitForSeconds(1f);

        
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.AddForce(rushVec);
    }
}
