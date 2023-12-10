using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvetoryMenu : MenuBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(open == false && Time.timeScale == 1)
            {
                OpenMenu();
            }
            else if (open == true && Time.timeScale == 0)
            {
                CloseMenu();
            }
        }
        if (open == true && Input.GetKeyUp(KeyCode.Escape))
        {
            CloseMenu();
        }
    }


}
