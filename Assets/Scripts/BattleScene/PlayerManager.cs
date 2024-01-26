using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
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

    [SerializeField] private Unit player;

    [SerializeField] private LayerMask obstacleMask;

    [SerializeField] private bool isJumping;

    [SerializeField] private float jumpPower;

    private int jumpCurrentCount, jumpMaxCount;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetOrAddComponent<BoxCollider2D>();
        rigidbody = gameObject.GetOrAddComponent<Rigidbody2D>();

        jumpPower = 12f;
        jumpMaxCount = 2;
    }

    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
            CheckCanJump();

        Jump();
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpCurrentCount++;
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void CheckCanJump()
    {
        float distance = collider.bounds.size.y * 0.5f + 0.05f;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, distance, obstacleMask);
        if (hit)
        {
            isJumping = false;
            jumpCurrentCount = 0;
        }
    }
}
