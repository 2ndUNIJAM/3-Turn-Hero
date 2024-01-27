using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bat : Monster
{
    private const float TURN_DISTANCE = 1.5f;
    private const float DEFAULT_FAINT_TIME = 1f;

    private bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        recognizeDis = 1f;
        outofDis = 8f;
        knockBackPower = 3f;
        hpbarHeight = 0.75f;
        upPos = Vector3.up;

        isCanAttack = true;
        isJump = false;
    }

    private void FixedUpdate()
    {
        if (isAttacking || isDead)
            return; // 공격 중엔 아래 기능을 수행하지 않음

        if (RecognizePlayer())
        {
            Player unit = PlayerManager.Instance.Player;
            int realDamage = unit.Stat.DEF - Stat.DEF;
            realDamage = Mathf.Clamp(realDamage, 0, realDamage);
            unit.ReduceHP(realDamage);

            FloatingDamage damageUI = BattleManager.Instance.BattleUI.CreateFloatingDamage();
            damageUI.Init(unit.gameObject, realDamage, PlayerManager.Instance.Player.UpPos, new Color(1f, 0.4f, 0.4f));

            ReduceHP(999);
        }
        else
        {
            Fly();
            if (!isJump)
                StartCoroutine("Jump");
        }

        if (rigidbody.velocity.y < -5f)
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -5f);
    }

    public override void ReduceHP(int damage)
    {
        if (isDead) return;

        ChangedStat.CurrentHP -= damage;
        CheckDead();

        StartHitAnim(DEFAULT_FAINT_TIME);
        StartCoroutine(StartFaint(DEFAULT_FAINT_TIME));
    }

    public void Fly()
    {
        float gap_x = Mathf.Abs(PlayerManager.Instance.transform.position.x - transform.position.x);
        gap_x = Mathf.Clamp(gap_x, 2f, 4f);

        if (isGotoRight)
        {
            Move(Vector3.right, gap_x * Stat.GetRealMoveSpeed);
            if (transform.position.x >= PlayerManager.Instance.transform.position.x + TURN_DISTANCE)
                isGotoRight = false;
        }
        else
        {
            Move(Vector3.left, gap_x * Stat.GetRealMoveSpeed);
            if (transform.position.x + TURN_DISTANCE <= PlayerManager.Instance.transform.position.x)
                isGotoRight = true;
        }
    }

    IEnumerator Jump()
    {
        isJump = true;
        if (PlayerManager.Instance.transform.position.y > this.transform.position.y)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * Random.Range(3f, 4f), ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(0.5f);

        isJump = false;
    }

    private void Move(Vector3 dir, float moveSpeed)
    {
        this.transform.position += dir * moveSpeed * Time.deltaTime;
        this.transform.localScale = (dir.x < 0f) ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
    }
}
