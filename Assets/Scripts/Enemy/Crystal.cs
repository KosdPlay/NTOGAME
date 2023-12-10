using System.Collections;
using UnityEngine;

public class Crystal : Enemy
{
    public GameObject projectilePrefab;

    private bool isPlayerLeft = false;
    private bool isPlayerAbove = false;

    private bool isShooting = false;

    private Animator animator;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (player != null && !isShooting)
        {
            UpdatePlayerPosition();
            StartCoroutine(AttackCoroutine());
        }

    }

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private IEnumerator AttackCoroutine()
    {
        if (isShooting)
        {
            yield break;
        }

        isShooting = true;

        yield return new WaitForSeconds(1f);

        AttackPlayer();


        isShooting = false;
    }

    protected override void AttackPlayer()
    {
        if (player == null)
        {
            return;
        }

        if (nextToPlayer && isPlayerLeft && !isPlayerAbove)
        {
            ShootSingleProjectile();
            animator.SetBool("Attack", true);
        }
        else if (nextToPlayer && isPlayerLeft && isPlayerAbove)
        {
            StartCoroutine(ShootTripleProjectileUpCoroutine());
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
            Debug.Log("lgyuigklygluirfd");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            isPlayerAbove = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerAbove = false;
        }
    }

    private void UpdatePlayerPosition()
    {
        float horizontalDistance = player.transform.position.x - transform.position.x;
        float verticalDistance = player.transform.position.y - transform.position.y;

        isPlayerLeft = horizontalDistance < 0;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        nextToPlayer = distanceToPlayer <= detectionRange && !CheckObstacleBetweenEnemyAndPlayer();
    }

    private void ShootSingleProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Debug.Log("Shoot Single Projectile");
    }

    private IEnumerator ShootTripleProjectileUpCoroutine()
    {
        for (int i = 0; i < 3; i++)
        {
            ShootTripleProjectileUp();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void ShootTripleProjectileUp()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, -90));
        Debug.Log("Shoot Triple Projectile Up");
    }
}
