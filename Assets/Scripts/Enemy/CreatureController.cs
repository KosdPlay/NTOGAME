using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float fleeSpeed = 4f;
    public float patrolTime = 3f;
    public float fleeTime = 2f;
    public string playerTag = "Player";

    private Rigidbody2D rb;
    private Transform player;
    private Vector2 patrolDirection;
    private float patrolTimer;
    private float fleeTimer;
    private bool fleeing;

    public void Died()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        SetRandomPatrolDirection();
    }

    void Update()
    {
        if (!fleeing)
        {
            Patrol();
        }
        else
        {
            Flee();
        }
    }

    void Patrol()
    {
        patrolTimer += Time.deltaTime;

        if (patrolTimer < patrolTime)
        {
            rb.velocity = new Vector2(patrolDirection.x * patrolSpeed, rb.velocity.y);
        }
        else
        {
            SetRandomPatrolDirection();
            patrolTimer = 0f;
        }

        CheckForPlayer();
    }

    void Flee()
    {
        fleeTimer += Time.deltaTime;

        if (fleeTimer < fleeTime)
        {
            Vector2 fleeDirection = transform.position - player.position;
            rb.velocity = fleeDirection.normalized * fleeSpeed;

            // Instantly rotate towards the flee direction
            float angle = Mathf.Atan2(fleeDirection.y, fleeDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
        else
        {
            fleeing = false;
            SetRandomPatrolDirection();
            fleeTimer = 0f;
        }
    }

    void SetRandomPatrolDirection()
    {
        patrolDirection = new Vector2(Random.Range(-1f, 1f), 0f).normalized;
        FlipSprite();
    }

    void CheckForPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f);

        foreach (Collider2D col in hitColliders)
        {
            if (col.CompareTag(playerTag))
            {
                fleeing = true;
                return;
            }
        }

        fleeing = false;
    }

    void FlipSprite()
    {
        if (patrolDirection.x > 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (patrolDirection.x < 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
    }
}