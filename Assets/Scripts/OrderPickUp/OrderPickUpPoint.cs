using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class OrderPickUpPoint : MonoBehaviour
{
    [SerializeField] End end;
    [SerializeField] private List<TextMeshProUGUI> textNumber = new List<TextMeshProUGUI>();
    [SerializeField] private List<Image> images = new List<Image>();
    [SerializeField] private int numberOrder = 0;
    [SerializeField] TextMeshProUGUI orderDescriptionText;
    [SerializeField] private string[] descriptionsOrder = new string[10];

    [SerializeField] private List<Item> allItems = new List<Item>();
    [SerializeField] private List<Item> order = new List<Item>();
    private List<int> numberOfItems = new List<int>();
    [SerializeField] private int[] payments = new int[9];

    [SerializeField] Player player;

    private int currentDay;

    private void SetOrder()
    {
        currentDay = ChangeDay.instance.GetDay();

        switch (numberOrder)
        {
            case 0:
                if (currentDay == 1)
                {
                    order.Add(allItems[2]);

                    numberOfItems.Add(1);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 1:
                if (currentDay == 1)
                {
                    order.Add(allItems[1]);

                    numberOfItems.Add(1);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 2:
                if (currentDay == 1)
                {
                    order.Add(allItems[0]);

                    numberOfItems.Add(1);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 3:
                if (currentDay == 2)
                {
                    order.Add(allItems[3]);
                    order.Add(allItems[2]);

                    numberOfItems.Add(1);
                    numberOfItems.Add(1);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 4:
                if (currentDay == 2)
                {
                    order.Add(allItems[4]);

                    numberOfItems.Add(2);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 5:
                if (currentDay == 2)
                {
                    order.Add(allItems[4]);
                    order.Add(allItems[0]);

                    numberOfItems.Add(1);
                    numberOfItems.Add(1);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 6:
                if (currentDay == 3)
                {
                    order.Add(allItems[3]);

                    numberOfItems.Add(3);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 7:
                if (currentDay == 3)
                {
                    order.Add(allItems[2]);

                    numberOfItems.Add(2);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;
            case 8:
                if (currentDay == 3)
                {
                    order.Add(allItems[1]);
                    order.Add(allItems[4]);

                    numberOfItems.Add(2);
                    numberOfItems.Add(1);
                }
                else
                {
                    NextOrder();
                    return;
                }
                break;

            default:
                break;
        }
        UpdateUI();
    }


    private void UpdateUI()
    {
        orderDescriptionText.text = descriptionsOrder[numberOrder];

        if (order.Count == 2)
        {
            textNumber[1].enabled = true;
            textNumber[0].enabled = true;
            images[0].enabled = true;
            images[1].enabled = true;

            images[0].sprite = order[0].itemImage;
            textNumber[0].text = InventoryManager.instance.GetItemCount(order[0].itemType) + "/" + numberOfItems[0];

            images[1].sprite = order[1].itemImage;
            textNumber[1].text = InventoryManager.instance.GetItemCount(order[1].itemType) + "/" + numberOfItems[1];
        }
        else if(order.Count == 1)
        {
            textNumber[0].enabled = true;
            images[0].enabled = true;

            images[0].sprite = order[0].itemImage;
            textNumber[0].text = InventoryManager.instance.GetItemCount(order[0].itemType) + "/" + numberOfItems[0];

            images[1].enabled = false;
            textNumber[1].enabled = false;
        }
        else if(order.Count == 0)
        {
            images[0].enabled = false;
            textNumber[0].enabled = false;
            images[1].enabled = false;
            textNumber[1].enabled = false;
        }
    }

    private void Clear()
    {
        order.Clear();
        numberOfItems.Clear();
    }

    private void NextOrder()
    {
        Clear();

        if (numberOrder + 1 < GetMaxOrdersForCurrentDay())
        {
            numberOrder++;

            SetOrder();
        }
        else if(ChangeDay.instance.isEndDay)
        {
            Clear();
            UpdateUI();
            ChangeDay.instance.NextDay();
            orderDescriptionText.text = descriptionsOrder[9];
        }
        else
        {
            Clear();

            UpdateUI();
            orderDescriptionText.text = descriptionsOrder[9];
        }

    }

    private void OnEnable()
    {
        SetOrder();
    }

    private void OnDisable()
    {
        Clear();
    }

    public void SubmitOrder()
    {
        if (numberOrder == 8)
        {
            end.FarewellWords(1);
        }
        if (order.Count == 2)
        {
            if (InventoryManager.instance.GetItemCount(order[0].itemType) == numberOfItems[0] && InventoryManager.instance.GetItemCount(order[1].itemType) == numberOfItems[1])
            {
                InventoryManager.instance.RemoveItem(order[0].itemType);
                InventoryManager.instance.RemoveItem(order[1].itemType);
                NextOrder();
                player.SetGold(payments[numberOrder]);
            }
        }
        else if(order.Count == 1)
        {
            if (InventoryManager.instance.GetItemCount(order[0].itemType) == numberOfItems[0])
            {
                InventoryManager.instance.RemoveItem(order[0].itemType);
                NextOrder();
                player.SetGold(payments[numberOrder]);
            }
        }
        else
        {
            Clear();
        }
    }

    public void SkipOrder()
    {
        if (numberOrder == 8)
        {
            end.FarewellWords(1);
        }
        NextOrder();

    }

    private int GetMaxOrdersForCurrentDay()
    {
        // В этом примере, предположим, что у вас есть 3 дня и для каждого дня разное максимальное количество заказов
        switch (currentDay)
        {
            case 1:
                return 3; // Максимальное количество заказов для первого дня
            case 2:
                return 6; // Максимальное количество заказов для второго дня
            case 3:
                return 9; // Максимальное количество заказов для третьего дня
            default:
                return 0; // Вернуть 0 или другое значение по умолчанию для неверных значений currentDay
        }
    }
}
