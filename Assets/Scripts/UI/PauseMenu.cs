using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MenuBase
{

    private void Start()
    {
        Resume();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !open && Time.timeScale == 1)
        {
            OpenMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && open && Time.timeScale == 0)
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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
