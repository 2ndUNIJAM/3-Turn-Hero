using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private const float ATTACK_DISTANCE = 1.5f;

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get { return instance; }
        set
        {
            if (instance == null)
                instance = value;
        }
    }

    private new BoxCollider2D collider;
    private new Rigidbody2D rigidbody;
    private Animator animator;

    [SerializeField] private Unit player;

    [SerializeField] private LayerMask obstacleMask, enemyMask;

    [SerializeField] private bool isJumping;

    [SerializeField] private float jumpPower;

    private int jumpCurrentCount, jumpMaxCount;
    private bool isCanAttack;
    private bool isCanMove;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetOrAddComponent<BoxCollider2D>();
        rigidbody = gameObject.GetOrAddComponent<Rigidbody2D>();
        animator = gameObject.GetOrAddComponent<Animator>();

        jumpPower = 12f;
        jumpMaxCount = 2;
        isCanAttack = true;
        isCanMove = true;
    }

    void FixedUpdate()
    {
        if (isCanMove)
            Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
            CheckCanJump();

        if (Input.GetKeyDown(KeyCode.W))
            Jump();

        if (Input.GetMouseButtonDown(0) && isCanAttack)
            Attack();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0f)
        {
            Vector2 movePos = (Vector2)this.gameObject.transform.position + Vector2.right * horizontal * player.Stat.MoveSpeed * Time.deltaTime;
            rigidbody.position = movePos;

            if (horizontal > 0f)
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            else
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void Jump()
    {
        if (isJumping && jumpCurrentCount <= jumpMaxCount)
            return;

        isJumping = true;
        jumpCurrentCount++;
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void CheckCanJump()
    {
        float distance = collider.bounds.size.y * 0.5f - collider.offset.y + 0.05f;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, distance, obstacleMask);
        if (hit)
        {
            isJumping = false;
            jumpCurrentCount = 0;
        }
    }

    private void Attack()
    {
        //isCanMove = false;
        animator.speed = player.Stat.AttackSpeed;
        animator.SetBool("isAttack", true);

        StartCoroutine(EndAttack());
        StartCoroutine(AttackCoolTime());
    }

    public void CheckAttackDamage()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 2, 0f, Vector2.right * Mathf.Sign(transform.localScale.x), ATTACK_DISTANCE, enemyMask);

        if (hit)
        {
            Unit unit = hit.transform.GetComponent<Unit>();
            unit.ReduceHP(player.Stat.PPower);
            Debug.Log(unit.Stat.CurrentHP);
        }
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(1f / player.Stat.AttackSpeed);

        isCanMove = true;
        animator.speed = 1f;
        animator.SetBool("isAttack", false);
    }

    IEnumerator AttackCoolTime()
    {
        isCanAttack = false;
        yield return new WaitForSeconds(1f / player.Stat.AttackSpeed);
        isCanAttack = true;
    }
}