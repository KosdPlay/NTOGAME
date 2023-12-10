using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrderPickUpPointMenu : MenuBase
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ChangeDay.instance.isEndDay)
            {
                HintConclusion("Нажмите E");
            }
            else
            {
                HintConclusion("Почтомат заработает только в конце дня");
            }
            if (Input.GetKey(KeyCode.E) && !open && ChangeDay.instance.isEndDay)
            {
                OpenMenu();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HideHint();
        }
    }


    new public void CloseMenu()
    {
        Resume();
        menu.SetActive(false);
        open = false;
    }
}
