using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float attackCooldown = 1.0f;
    private float lastAttackTime;

    public bool isAttacking = false;

    private bool canAttack = true;

    private bool damageDone = false;

    private void Start()
    {
        lastAttackTime = -attackCooldown;
    }

    public void FixedUpdate()
    {
        if (canAttack && Time.time - lastAttackTime >= attackCooldown)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                StartCoroutine(PerformAttack());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (isAttacking && damageDone == false && collision.GetComponent<LiveChanterelle>() != null)
            {
                collision.GetComponent<LiveChanterelle>().TakeDamage(damage);
                Debug.Log("Бац");
                damageDone = true;
            }
            else if (isAttacking && damageDone == false && collision.GetComponent<Crystal>() != null)
            {
                collision.GetComponent<Crystal>().TakeDamage(damage);
                Debug.Log("Бац");
                damageDone = true;
            }
            else if(isAttacking && damageDone == false && collision.GetComponent<CreatureController>() != null)
            {
                Debug.Log("Бац");
                damageDone = true;
                collision.GetComponent<CreatureController>().Died();
            }
        }
    }

    private IEnumerator PerformAttack()
    {
        canAttack = false;
        damageDone = false;
        isAttacking = true;
        yield return new WaitForSeconds(0.7f);
        isAttacking = false;

        lastAttackTime = Time.time;
        canAttack = true; 
    }

    public bool CanAttack()
    {
        return canAttack;
    }

    public void SetDamage()
    {
        damage = 20;
    }

}
