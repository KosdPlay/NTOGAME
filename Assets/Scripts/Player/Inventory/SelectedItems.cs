using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItems : Hint
{
    [SerializeField] Item item;
    private bool hasBeenCollected = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.timeScale == 1)
        {
            if (other.CompareTag("Player") && !hasBeenCollected)
            {
                HintConclusion("ֽאזלטעו E");
                if (Input.GetKey(KeyCode.E))
                {
                    if (item != null)
                    {
                        Item newItem = Instantiate(item);
                        newItem.quantity = 1;
                        newItem.itemType = DetermineItemType(item);
                        newItem.itemDescription = DetermineItemDescription(item);

                        InventoryManager.instance.AddItem(newItem);
                        Destroy(this.gameObject);
                        hasBeenCollected = true;
                    }
                    else
                    {
                        Debug.LogError("Item is null. Make sure to assign an Item in the Inspector.");
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Time.timeScale == 1)
        {
            if (other.CompareTag("Player") && !hasBeenCollected)
            {
                HideHint();
            }
        }
    }

    private ItemType DetermineItemType(Item item)
    {
        return item.itemType;
    }

    private string DetermineItemDescription(Item item)
    {
        return item.itemDescription;
    }
}
