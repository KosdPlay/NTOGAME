using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Attack attack;

    [SerializeField] GameObject point;

    [SerializeField] private int gold = 100;

    [SerializeField] private Image lineBar;
    [SerializeField] private int hp = 100;

    private int hpRecoveryRate = 5; // �������� �������������� �� � �������
    private int hpRecoveryCooldown = 3; // ����� ����� ���������������� ��
    private bool isHpRecovering = false;

    [SerializeField] private bool isHpRecoveryEnabled;

    private Animator animator ;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
        UpdateUI();
        if (hp <= 0)
        {
            Debug.Log("��");
            Death();
        }


    }

    public void EnableEnhancedImpact()
    {
        animator.SetBool("EnhancedImpact", true);
        attack.SetDamage();
    }

    private void Start()
    {
        animator = this.GetComponent<Animator>();

        isHpRecoveryEnabled = false;
    }

    public int GetGold()
    {
        return gold;
    }

    public void SetGold(int price)
    {
        gold += price;
        Debug.Log(gold);
    }

    private void Death()
    {
        this.transform.position = point.transform.position;
        hp = 100;
        UpdateUI();
    }

    private void HpRecovery()
    {
        if (isHpRecovering)
        {
            hp += hpRecoveryRate;
            UpdateUI();
        }

        if (hp >= 100)
        {
            hp = 100;
            UpdateUI();
            isHpRecovering = false;
        }
    }

    private void Update()
    {
        if (!isHpRecovering && hp <= 100 && isHpRecoveryEnabled == true)
        {
            isHpRecovering = true;
            InvokeRepeating("HpRecovery", hpRecoveryCooldown, hpRecoveryCooldown);
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(30);
        }
    }

    void UpdateUI()
    {
        lineBar.fillAmount = (float)hp / 100;
    }

    public void EnableHpRecovery()
    {
        isHpRecoveryEnabled = true;
    }
}
