using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeDay : MonoBehaviour
{
    [SerializeField] Diary diaryScript;
    [SerializeField] GameObject point, player, doorOpen, doorClose;
    [SerializeField] private float lengthOfDay = 300;
    [SerializeField] private float timer;
    public bool isEndDay = true;
    [SerializeField] private int day = 0;

    [SerializeField] private Image timerImage;
    [SerializeField] private TextMeshProUGUI dayText;

    public static ChangeDay instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        NextDay();
    }

    private void Update()
    {


        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timerImage.fillAmount = (float)timer / 300;
        }
        else if(!isEndDay)
        {
            player.transform.position = point.transform.position;

            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in gos)
                Destroy(go);
            GameObject[] gos1 = GameObject.FindGameObjectsWithTag("mushrooms");
            foreach (GameObject go1 in gos1)
                Destroy(go1);
            isEndDay = true;
            timer = 0;
            if (day == 1)
            {
                diaryScript.HandleStoryTrigger(null, "1", "");
            }
            else if(day == 2)
            {
                diaryScript.HandleStoryTrigger(null, "2", "");
            }
            doorOpen.SetActive(false);
            doorClose.SetActive(true);
        }
    }

    public void NextDay()
    {
        if (isEndDay == true)
        {
            day++;
            timer = lengthOfDay;
            isEndDay = false;
            dayText.text = day.ToString() + "/3";
            doorOpen.SetActive(true);
            doorClose.SetActive(false);
        }
    }

    public int GetDay()
    {
        return day;
    }

}
