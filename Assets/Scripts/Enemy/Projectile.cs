using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; // �������� ����� �������
    public float lifetime = 2f; // ����� ����� �������
    public int damage = 10; // ����, ������� ������ �������

    void Start()
    {
        // ��������� �������� ��� ����������� ������� ����� lifetime ������
        StartCoroutine(DestroyAfterLifetime());
    }

    void Update()
    {
        // ����������� ������� ����� �� �����������
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    IEnumerator DestroyAfterLifetime()
    {
        // ����� lifetime ������, ����� ���������� ������
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� ������������ � ������� ���������
        if (other.CompareTag("Player"))
        {
            // ���� ����������� � �������, ������� ����� TakeDamage � ������
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            // ���������� ������ ����� ������������ � �������
            Destroy(gameObject);
        }
    }
}
