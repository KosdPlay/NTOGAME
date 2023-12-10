using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D rb;
    private float horizontalMove;
    private bool facingRight = true;
    private int jumpsRemaining;
    private float previousVerticalVelocity;
    private bool DoubleJump = false; 

    [Header("Player Movement Settings")]
    [Range(0, 100f)] [SerializeField] private float speed;
    [Range(0, 100f)] [SerializeField] private float jumpForce;

    [Space]
    [Header("Additional Abilities Settings")]
    private int maxJumps;
    private bool slowLanding;
    private bool isDash;
    [SerializeField] private float dashFarce;

    [Space]
    [Header("Player Animation Settings")]
    [SerializeField] Animator animator;

    [Space]
    [Header("Ground Checker Settings")]
    [SerializeField] private bool isGrounded;
    [Range(-5, 5f)] [SerializeField] private float checkGroundOffsetY;
    [Range(0, 15f)] [SerializeField] private float checkGroundRadius;

    [Space]
    [Header("Ground Checker Settings")]
    [SerializeField] private LayerMask groundLayer;

    [Space]
    [Header("dfker Settings")]
    [SerializeField] private Attack attack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Time.timeScale == 1)
        {

            Jamp();

            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

            if (facingRight && horizontalMove < 0)
            {
                Flip();
            }
            else if (!facingRight && horizontalMove > 0)
            {
                Flip();
            }

            Attack();

            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        SlowLanding();

        GroundChecker();

        AnimationPlayer();
    }

    private void Jamp()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpsRemaining = maxJumps - 1;

        }
        else if (!isGrounded && jumpsRemaining > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            DoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpsRemaining--;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void GroundChecker()
    {
        float checkRadius = checkGroundRadius;
        Vector2 checkPosition = new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, checkRadius, groundLayer);

        isGrounded = false;

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                DoubleJump = false;
                isGrounded = true;
                rb.gravityScale = 2;
                break;
            }
        }
    }

    private void AnimationPlayer()
    {
        animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove));

        if (DoubleJump == true && !isGrounded)
        {
            animator.SetBool("DoubleJumping", true);
            animator.SetBool("Jumping", false);
        }
        else if (isGrounded && DoubleJump == false)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("DoubleJumping", false);
        }
        else
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("DoubleJumping", false);
        }


        animator.SetBool("Attack", attack.isAttacking);
    }


    IEnumerator ReloadDash()
    {
        isDash = false;

        yield return new WaitForSeconds(2);

        isDash = true;

    }


    IEnumerator Dash()
    {
        if (isDash && Input.GetKeyDown(KeyCode.F))
        {
            float x = 10000;
            float dashStartTime = Time.time;
            float dashEndTime = dashStartTime + 0.2f; // Здесь настраиваем длительность рывка

            while (Time.time < dashEndTime)
            {
                if (facingRight)
                {
                    rb.AddForce(dashFarce * Time.deltaTime * x * transform.right);
                }
                else
                {
                    rb.AddForce((-dashFarce) * Time.deltaTime * x * transform.right);
                }

                yield return null;
            }

            StartCoroutine(ReloadDash());
        }
    }


    void SlowLanding()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y < 0f && previousVerticalVelocity > 0f && slowLanding)
            {
                Debug.Log("Player reached maximum jump point");
                rb.gravityScale = 0.5f;
            }

            if (rb.velocity.y > 0f && previousVerticalVelocity < 0f && slowLanding)
            {
                Debug.Log("Player reached minimum jump point");
                rb.gravityScale = 2;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.gravityScale = 2;
        }

            previousVerticalVelocity = rb.velocity.y;
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && attack.CanAttack())
        {
            attack.StartCoroutine("PerformAttack");
        }
    }

    public void SetMaxJumps(int max)
    {
        maxJumps = max;
    }

    public void SetSlowLanding(bool active)
    {
        slowLanding = active;
    }

    public void SetDash(bool active)
    {
        isDash = active;
    }
}
