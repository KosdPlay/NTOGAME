using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{
    public float patrolRange = 5f; // ��������� ��������������
    public float chargeDistance = 3f; // ���������� ��� �����
    public float chargeSpeed = 10f; // �������� �����
    public float chargeCooldown = 3f; // ����������� �����
    public float attackDistance = 1f; // ���������� ��� ��������� �����

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
            // ��������� ������
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // ���������, ������ �� ��������� �������� �����
            if (currentPosition.x >= originalPosition.x + patrolRange)
            {
                isMovingRight = false;
            }
        }
        else
        {
            // ��������� �����
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // ���������, ������ �� ��������� ��������� �����
            if (currentPosition.x <= originalPosition.x - patrolRange)
            {
                isMovingRight = true;
            }
        }
    }

    private void CheckCharge()
    {
        // ���������, ��������� �� ����� ������� ���������� �� �������� ����������
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // ��������� ���������� nextToPlayer � ������������ � ����������� �� ������
        nextToPlayer = distanceToPlayer <= attackDistance && !CheckObstacleBetweenEnemyAndPlayer();

        if (distanceToPlayer <= chargeDistance)
        {
            StartCoroutine(Charge());
        }
    }

    private IEnumerator Charge()
    {
        isCharging = true;

        // ���������, ��������� �� ����� � ���� �����
        if (nextToPlayer)
        {
            // ������� ���� ������
            player.GetComponent<Player>().TakeDamage(damage);
        }

        // ����� � ������
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float distanceToCharge = chargeDistance;

        while (distanceToCharge > 0f)
        {
            transform.Translate(direction * chargeSpeed * Time.deltaTime);
            distanceToCharge -= chargeSpeed * Time.deltaTime;
            yield return null;
        }

        // �����������
        yield return new WaitForSeconds(chargeCooldown);

        isCharging = false;
    }
}
