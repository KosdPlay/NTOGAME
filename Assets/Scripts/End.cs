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
            text.text = "Вы выполнили все задания, больше интересных заданий вы увидите в финале НТО";
        }
        else
        {
            text.text = "О том, что скрывается по ту сторону вы узнаете в финале НТО";
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
