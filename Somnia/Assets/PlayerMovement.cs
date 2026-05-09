using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private float moveInput;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput < 0)
            sr.flipX = false;
        else if (moveInput > 0)
            sr.flipX = true;

        // DEBUG JUMP TEST
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * 12f;
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}