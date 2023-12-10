using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool nextToPlayer = false;
    [SerializeField] protected int hp;
    [SerializeField] protected int damage;

    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject drop;

    [SerializeField] protected float detectionRange;
    [SerializeField] protected float attackInterval;

    [SerializeField] protected float moveSpeed;

    protected virtual void Start()
    {
        InvokeRepeating("AttackPlayer", attackInterval, attackInterval);
    }

    protected virtual void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        if (hp <= 0)
        {
            Death();
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionRange && !CheckObstacleBetweenEnemyAndPlayer())
        {
            MoveTowardsPlayer();
        }
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (!nextToPlayer)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    protected virtual void AttackPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionRange && !CheckObstacleBetweenEnemyAndPlayer())
        {
            Debug.Log(damage);
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
        }
    }

    protected bool CheckObstacleBetweenEnemyAndPlayer()
    {
        if (player == null)
        {
            return false;
        }

        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = (playerPosition - enemyPosition).normalized;
        float distance = Vector2.Distance(enemyPosition, playerPosition);

        RaycastHit2D hit = Physics2D.Raycast(enemyPosition, direction, distance, LayerMask.GetMask("Ground"));
        Debug.DrawRay(enemyPosition, direction * distance, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Obstacle"))
        {
            return true;
        }

        return false;
    }

    public void Death()
    {
        if (drop != null)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
