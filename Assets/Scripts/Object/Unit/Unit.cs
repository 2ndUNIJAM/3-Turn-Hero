using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private const float DEAD_FADE_SPEED = 2f;

    public UnitDataSO Data;

    [SerializeField] private Stat changedStat;
    public Stat ChangedStat => changedStat;

    public Stat Stat => Data.Stat + changedStat;

    protected float knockBackPower;
    protected bool isHit;
    protected bool isDead;

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
        changedStat.MaxHP += hp;
        changedStat.CurrentHP += hp;
    }

    public virtual void AddHP(int hp) => changedStat.CurrentHP += hp;

    public virtual void ReduceHP(int damage)
    {
        changedStat.CurrentHP -= damage;
        CheckDead();
        StartHitAnim();
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

        GameManager.Resource.Destroy(this.gameObject);
    }

    private void StartHitAnim()
    {
        rigidbody.AddForce(Vector2.left * Mathf.Sign(transform.localScale.x) * knockBackPower, ForceMode2D.Impulse);
        animator.SetBool("isHit", true);
        isHit = true;
    }

    public void EndHitAnim()
    {
        if (isDead)
            return;

        rigidbody.velocity = Vector2.zero;
        animator.SetBool("isHit", false);
        isHit = false;
    }
}
