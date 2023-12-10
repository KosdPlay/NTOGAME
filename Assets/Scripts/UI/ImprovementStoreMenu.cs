using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImprovementStoreMenu : MenuBase
{
    [SerializeField] Panel panel;
    Player player;

    [SerializeField] private int idButton = -1;

    [SerializeField] TextMeshProUGUI description;

    [SerializeField] TextMeshProUGUI gold;

    private readonly string[] welcomeSpeech = {"Ну привет", "Давное не виделись", "Для тебя кое-что есть", "Заходи не пожалеешь"};

    [SerializeField] private string[] descriptionItems = new string[11];

    [SerializeField] private List<GameObject> purchasedItems = new List<GameObject>();

    [SerializeField] int[] price = new int[11];
    [SerializeField] private int[] count = new int[11];

    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

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

    void UpdateGold()
    {
        gold.text = "Деньги: " + player.GetGold();
    }


    new public void CloseMenu()
    {
        Resume();
        menu.SetActive(false);
        open = false;
    }


    new private void OpenMenu()
    {
        Pause();
        menu.SetActive(true);
        open = true;
        description.text = welcomeSpeech[Random.Range(0, welcomeSpeech.Length)];
        UpdateGold();
    }

    public void SelectDoubleJamp()
    {
        idButton = 0;
        description.text = descriptionItems[idButton];
    }

    public void SelectDash()
    {
        idButton = 1;
        description.text = descriptionItems[idButton];
    }

    public void SelectSlowLanding()
    {
        idButton = 2;
        description.text = descriptionItems[idButton];
    }

    public void SelectWater()
    {
        idButton = 3;
        description.text = descriptionItems[idButton];
    }

    public void SelectPot()
    {
        idButton = 4;
        description.text = descriptionItems[idButton];
    }

    public void SelectBaseForOintment()
    {
        idButton = 5;
        description.text = descriptionItems[idButton];
    }

    public void SelectProtectiveField()
    {
        idButton = 6;
        description.text = descriptionItems[idButton];
    }

    public void SelectAutomaticTreatment()
    {
        idButton = 7;
        description.text = descriptionItems[idButton];
    }

    public void SelectEnhancedImpact()
    {
        idButton = 8;
        description.text = descriptionItems[idButton];
    }

    public void SelectIncreasingInventory()
    {
        idButton = 9;
        description.text = descriptionItems[idButton];
    }

    public void SelectIncreasingNumberOfBlocks()
    {
        idButton = 10;
        description.text = descriptionItems[idButton];
    }



    public void Buy()
    {
        if(idButton == -1)
        {

        }
        else if (player.GetGold() >= price[idButton] && count[idButton] > 0)
        {
            switch (idButton)
            {
                case 6:
                    LaunchProtectiveField.instance.EnableProtectiveZone();
                    break;
                case 7:
                    player.EnableHpRecovery();
                    break;
                case 8:
                    player.EnableEnhancedImpact();
                    break;
                case 9:
                    InventoryManager.instance.IncreasingInventory();
                    break;
                case 10:
                    panel.AddPoint();
                    break;

                default:
                    Instantiate(purchasedItems[idButton], spawnPoint.position, Quaternion.identity);
                    break;
            }
            player.SetGold(price[idButton]);
            count[idButton]--;
            UpdateGold();
            if (count[idButton] <= 0)
            {
                idButton = -1;
            }
        }
        else if (count[idButton] > 0 && player.GetGold() < price[idButton])
        {
            description.text = "Не хватает денег.";
        }
        else
        {
            description.text = "Уже куплено.";
        }
    }
}
