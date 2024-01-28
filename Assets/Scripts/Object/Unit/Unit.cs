using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private const float DEAD_FADE_SPEED = 2f;

    public UnitDataSO Data;

    public Stat ChangedStat; // 배틀 씬에서만 변경되는 스탯

    public Stat Stat => Data.Stat + ChangedStat;

    protected Vector3 upPos;
    public Vector3 UpPos => upPos;

    protected float knockBackPower;
    protected bool isHit;
    protected bool isFaint; // 경직
    protected bool isDead;

    // 지속 피해 데미지.
    // 지속 피해량이 더 높아지는 효과가 새로 들어오는 경우 기존 효과를 갱신
    // 지속 피해량이 같거나 낮은 효과가 새로 들어오는 경우 기존 효과의 지속 시간이 남아 있는 동안에는 아무 효과 없음
    // 지속 시간은 어떤 효과든 3초.
    // 지속 피해를 안 주고 있는 동안에는 dottedDamageAmount == 0
    protected int dottedDamageAmount = 0;

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected SpriteRenderer spriteRenderer;

    [SerializeField]
    protected new Collider2D collider;

    [SerializeField]
    protected new Rigidbody2D rigidbody;

    public virtual void CheckDead() 
    {
        if (Stat.CurrentHP <= 0f)
        {
            isDead = true;
            collider.enabled = false;
            rigidbody.bodyType = RigidbodyType2D.Static;
            StartCoroutine(FadeDeadOut());
        }
    }

    public virtual void AddMaxHP(int hp)
    {
        if (isDead) return;
        ChangedStat.MaxHP += hp;
        ChangedStat.CurrentHP += hp;
    }

    public virtual void AddHP(int hp) => ChangedStat.CurrentHP += hp;

    public virtual void ReduceHP(int damage)
    {
        if (isDead) return;
        ChangedStat.CurrentHP -= damage;
        CheckDead();
    }

    public virtual void ReduceHPPercent(float percent)
    {
        if (isDead) return;

        // 최대 체력 비례 데미지
        ChangedStat.CurrentHP -= Mathf.RoundToInt(ChangedStat.MaxHP * percent);
        CheckDead();
    }

    IEnumerator FadeDeadOut()
    {
        while (spriteRenderer.color.a > 0f)
        {
            Color color = spriteRenderer.color;
            color.a -= Time.deltaTime * DEAD_FADE_SPEED;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        //GameManager.Resource.Destroy(this.gameObject);
        gameObject.SetActive(false);
    }

    protected virtual void StartHitAnim(float endTime)
    {
        animator.SetBool("isHit", true);
        isHit = true;
        Invoke("EndHitAnim", endTime);
    }

    protected virtual void EndHitAnim()
    {
        if (isDead)
            return;

        animator.SetBool("isHit", false);
        isHit = false;
    }

    protected IEnumerator StartFaint(float faintTime)
    {
        isFaint = true;

        // 넉백
        rigidbody.AddForce(Vector2.left * Mathf.Sign(transform.localScale.x) * knockBackPower, ForceMode2D.Impulse);

        yield return new WaitForSeconds(faintTime);
        
        isFaint = false;

        if (rigidbody.bodyType != RigidbodyType2D.Static)
        {
            rigidbody.velocity = Vector2.zero;
        }
    }

    public void ApplyDottedDamage(int damage)
    {
        StartCoroutine(DottedDamage(damage));
    }

    IEnumerator DottedDamage(int damage)
    {
        if (dottedDamageAmount >= damage) yield break;

        dottedDamageAmount = damage;

        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);

            // 상위 효과로 갱신된 경우 기존에 작용하던 낮은 효과의 지속 데미지 제거
            if (dottedDamageAmount > damage) yield break;

            ReduceHP(damage);
            if (isDead)
            {
                dottedDamageAmount = 0;
                yield break;
            }
        }
        dottedDamageAmount = 0;
    }
}
