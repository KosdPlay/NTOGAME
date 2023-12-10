using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveZone : MonoBehaviour
{
    Enemy enemy;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.timeScale == 1)
        {
            if (other.CompareTag("Enemy"))
            {
                enemy = other.GetComponent<Enemy>();
                enemy.Death();
            }
        }
    }
}
