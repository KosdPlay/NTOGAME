using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{
    public float patrolRange = 5f; // Дистанция патрулирования
    public float chargeDistance = 3f; // Расстояние для рывка
    public float chargeSpeed = 10f; // Скорость рывка
    public float chargeCooldown = 3f; // Перезарядка рывка
    public float attackDistance = 1f; // Расстояние для нанесения урона

    private bool isMovingRight = true;
    private Vector2 originalPosition;
    private bool isCharging = false;

    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (!isCharging)
        {
            Patrol();
            CheckCharge();
        }
    }

    private void Patrol()
    {
        Vector2 currentPosition = transform.position;

        if (isMovingRight)
        {
            // Двигаться вправо
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Проверить, достиг ли противник конечной точки
            if (currentPosition.x >= originalPosition.x + patrolRange)
            {
                isMovingRight = false;
            }
        }
        else
        {
            // Двигаться влево
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // Проверить, достиг ли противник начальной точки
            if (currentPosition.x <= originalPosition.x - patrolRange)
            {
                isMovingRight = true;
            }
        }
    }

    private void CheckCharge()
    {
        // Проверить, находится ли игрок впереди противника на заданном расстоянии
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Обновляем переменную nextToPlayer в соответствии с расстоянием до игрока
        nextToPlayer = distanceToPlayer <= attackDistance && !CheckObstacleBetweenEnemyAndPlayer();

        if (distanceToPlayer <= chargeDistance)
        {
            StartCoroutine(Charge());
        }
    }

    private IEnumerator Charge()
    {
        isCharging = true;

        // Проверить, находится ли игрок в зоне атаки
        if (nextToPlayer)
        {
            // Нанести урон игроку
            player.GetComponent<Player>().TakeDamage(damage);
        }

        // Рывок к игроку
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float distanceToCharge = chargeDistance;

        while (distanceToCharge > 0f)
        {
            transform.Translate(direction * chargeSpeed * Time.deltaTime);
            distanceToCharge -= chargeSpeed * Time.deltaTime;
            yield return null;
        }

        // Перезарядка
        yield return new WaitForSeconds(chargeCooldown);

        isCharging = false;
    }
}
