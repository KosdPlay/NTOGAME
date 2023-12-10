using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject panel;

    public void FarewellWords(int end)
    {
        panel.SetActive(true);


        Time.timeScale = 0;
        if (end == 1)
        {
            text.text = "�� ��������� ��� �������, ������ ���������� ������� �� ������� � ������ ���";
        }
        else
        {
            text.text = "� ���, ��� ���������� �� �� ������� �� ������� � ������ ���";
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
