using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronMenu : MenuBase
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !open)
            {
                OpenMenu();
            }
        }
    }

    private void Update()
    {
        if (open == true && Input.GetKeyUp(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    new public void CloseMenu()
    {
        Resume();
        menu.SetActive(false);
        open = false;
    }

}
