using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Monster : Unit
{
    private const float TURN_DISTANCE = 1f;
    private const float MOVE_MIN_DISTANCE = 3f;
    private const float MOVE_MAX_DISTANCE = 6f;
    private const float DEFAULT_FAINT_TIME = 0.5f;

    protected float recognizeDis;
    protected float outofDis;
    protected float attackDis;
    protected float hpbarHeight;
    protected float attackTiming;
    protected bool isGotoRight;
    protected bool isChasing, isAttacking;
    protected bool isCanAttack;

    protected Coroutine patrolCo;

    [SerializeField] private HPBar hpBar;

    public override void CheckDead()
    {
        base.CheckDead();
        if (Stat.CurrentHP <= 0f)
        {
            if (hpBar != null)
                hpBar.DestroyHPBar();
            BattleManager.Instance.Stage.RemoveEnemyUnit(this);
        }
    }

    public override void ReduceHP(int damage)
    {
        if (isDead) return;

        base.ReduceHP(damage);
        StartHitAnim(DEFAULT_FAINT_TIME);
        StartCoroutine(StartFaint(DEFAULT_FAINT_TIME));

        if (hpBar == null && Stat.CurrentHP > 0f)
        {
            hpBar = BattleManager.Instance.BattleUI.CreateHPBar();
            hpBar.Init(this.gameObject, hpbarHeight);
        }

        if (hpBar != null)
            hpBar.SetSlider(Stat.CurrentHP, Stat.MaxHP);
    }

    protected virtual bool RecognizePlayer()
    {
        float distance = Vector2.Distance(this.transform.position, PlayerManager.Instance.transform.position);
        if (distance < recognizeDis)
            return true;
        else
            return false;
    }

    protected virtual bool CheckOutOfRange()
    {
        float distance = Vector2.Distance(this.transform.position, PlayerManager.Instance.transform.position);
        if (distance > outofDis)
            return true;
        else
            return false;
    }

    protected virtual bool CheckAttack()
        => Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(transform.localScale.x), attackDis, 128);

    protected virtual void GotoPlayer()
    {
        if (isDead || isFaint)
            return; // �װų� ������ ���

        if (isGotoRight)
        {
            Move(Vector3.right, Stat.GetRealMoveSpeed);
            if (transform.position.x >= PlayerManager.Instance.transform.position.x + TURN_DISTANCE)
                isGotoRight = false;
        }
        else
        {
            Move(Vector3.left, Stat.GetRealMoveSpeed);
            if (transform.position.x + TURN_DISTANCE <= PlayerManager.Instance.transform.position.x)
                isGotoRight = true;
        }
    }

    protected virtual void StopPatrol() => StopCoroutine(patrolCo);

    protected virtual IEnumerator Patrol()
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

        animator.SetBool("isWalk", false);

        yield return new WaitForSeconds(Random.Range(0.5f, 2f));

        patrolCo = StartCoroutine(Patrol());
    }

    private void Move(Vector3 dir, float moveSpeed)
    {
        animator.SetBool("isWalk", true);
        this.transform.position += dir * moveSpeed * Time.deltaTime;
        this.transform.localScale = (dir.x < 0f) ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
    }

    protected virtual void Attack()
    {
        isCanAttack = false;
        isAttacking = true;
        animator.speed = Stat.GetRealAttackSpeed;
        animator.SetBool("isAttack", true);

        Invoke("CheckAttackDamage", 0.5f / Stat.GetRealAttackSpeed);
        StartCoroutine(EndAttack());
    }

    protected virtual void CheckAttackDamage()
    {
        if (isDead) return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(transform.localScale.x), attackDis, 128);

        if (hit)
        {
            Unit unit = hit.transform.GetComponent<Unit>();
            int realDamage = Stat.ATK - unit.Stat.DEF;
            realDamage = Mathf.Clamp(realDamage, 1, realDamage);
            unit.ReduceHP(realDamage);
            
            FloatingDamage damageUI = BattleManager.Instance.BattleUI.CreateFloatingDamage();
            damageUI.Init(unit.gameObject, realDamage, PlayerManager.Instance.Player.UpPos, new Color(1f, 0.4f, 0.4f));
        }
    }

    protected virtual IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(1f / Stat.GetRealAttackSpeed);

        isCanAttack = true;
        isAttacking = false;
        animator.speed = 1f;
        animator.SetBool("isAttack", false);
    }
}
