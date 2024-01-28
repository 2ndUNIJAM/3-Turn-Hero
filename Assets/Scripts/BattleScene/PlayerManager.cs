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

    [SerializeField] private Animator weaponAnim;

    [SerializeField] private Player player;
    public Player Player => player;

    [SerializeField] private LayerMask obstacleMask, enemyMask;

    [SerializeField] private bool isJumping;

    [SerializeField] private float jumpPower;

    private int jumpCurrentCount, jumpMaxCount;
    private bool isCanAttack;
    private bool isCanMove;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player.InitFromDataManager();

        collider = gameObject.GetOrAddComponent<BoxCollider2D>();
        rigidbody = gameObject.GetOrAddComponent<Rigidbody2D>();
        animator = gameObject.GetOrAddComponent<Animator>();

        jumpPower = 14f;
        jumpMaxCount = Player.inven.armor.multiJump;

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
            Vector2 movePos = (Vector2)this.gameObject.transform.position + Vector2.right * horizontal * player.Stat.GetRealMoveSpeed * Time.deltaTime;
            rigidbody.position = movePos;
            animator.SetBool("isWalk", true);

            if (horizontal > 0f)
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            else
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            animator.SetBool("isWalk", false);
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
        float distance = collider.bounds.size.y * 0.5f - collider.offset.y;
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
        weaponAnim.speed = player.Stat.GetRealAttackSpeed;
        weaponAnim.SetBool("isAttack", true);
        GameManager.Sound.PlaySE("Sword");

        Invoke("CheckAttackDamage", 0.25f / player.Stat.GetRealAttackSpeed);
        StartCoroutine(EndAttack());
        StartCoroutine(AttackCoolTime());
    }

    public void CheckAttackDamage()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, Vector2.one * 2, 0f, Vector2.right * Mathf.Sign(transform.localScale.x), ATTACK_DISTANCE, enemyMask);
        int maxCount = 1;
        int currentCount = 0;

        foreach (var hit in hits)
        {
            Unit unit = hit.transform.GetComponent<Unit>();
            int realDamage = player.Stat.ATK - unit.Stat.DEF;
            realDamage = Mathf.Clamp(realDamage, 1, realDamage);

            player.inven.weapon.InvokeAttackEffect(player, unit);
            unit.ReduceHP(realDamage);

            currentCount++;
            if (currentCount == maxCount)
                break;
        }
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(1f / player.Stat.GetRealAttackSpeed);

        isCanMove = true;
        weaponAnim.speed = 1f;
        weaponAnim.SetBool("isAttack", false);
    }

    IEnumerator AttackCoolTime()
    {
        isCanAttack = false;
        yield return new WaitForSeconds(1f / player.Stat.GetRealAttackSpeed);
        isCanAttack = true;
    }
}
