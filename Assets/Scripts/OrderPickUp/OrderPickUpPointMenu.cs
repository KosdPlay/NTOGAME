using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrderPickUpPointMenu : MenuBase
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !open && ChangeDay.instance.isEndDay)
            {
                OpenMenu();
            }
        }
    }


    new public void CloseMenu()
    {
        Resume();
        menu.SetActive(false);
        open = false;
    }
}
