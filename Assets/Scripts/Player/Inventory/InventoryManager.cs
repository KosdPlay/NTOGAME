using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField] private int inventorySize = 20;
    [SerializeField] private GameObject inventorySlotPrefab;
    [SerializeField] private Transform inventoryPanel;

    public List<Item> inventory = new List<Item>();

    Player player;

    [SerializeField] TextMeshProUGUI gold;

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
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InitializeInventory();
    }

    void InitializeInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject slot = Instantiate(inventorySlotPrefab);
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

            slot.transform.SetParent(inventoryPanel, false);
        }
    }

    public void AddItem(Item newItem)
    {
        if (inventory.Count < inventorySize)
        {
            inventory.Add(newItem);
        }
        else
        {
            Debug.LogWarning("Inventory is full!");
        }

        UpdateUI();
    }

    public void RemoveItem(ItemType itemType)
    {
        Item itemToRemove = inventory.Find(item => item.itemType == itemType);

        if (itemToRemove != null)
        {
            inventory.Remove(itemToRemove);
            Debug.Log("Item removed successfully.");
        }
        else
        {
            Debug.LogWarning("Item not found in inventory.");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            InventorySlot inventorySlot = inventoryPanel.GetChild(i).GetComponent<InventorySlot>();

            if (i < inventory.Count)
            {
                inventorySlot.UpdateSlot(inventory[i]);
            }
            else
            {
                inventorySlot.UpdateSlot(null);
            }
        }
        UpdateGold();
    }

    void UpdateGold()
    {
        gold.text = "Δενόγθ: " + player.GetGold();
    }

    private void Update()
    {
        if (gold.enabled == true)
        {
            UpdateUI();
        }
    }

    public int GetItemCount(ItemType type)
    {
        return inventory.Count(item => item.itemType == type);
    }

    public void IncreasingInventory()
    {
        int additionalSlots = 30 - inventorySize;

        for (int i = 0; i < additionalSlots; i++)
        {
            GameObject slot = Instantiate(inventorySlotPrefab);
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
            slot.transform.SetParent(inventoryPanel, false);
        }

        inventorySize = 30;
        UpdateUI();

    }

}
