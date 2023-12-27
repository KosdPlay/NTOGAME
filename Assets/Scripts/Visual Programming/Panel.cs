using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] DronMenu dronMenu;
    private RectTransform parentRectTransform;
    [SerializeField] private List<RectTransform> point = new List<RectTransform>();
    [SerializeField] private List<bool> occupied = new List<bool>();
    [SerializeField] private List<Block> blocks = new List<Block>();
    private int maxPoints = 5;

    [SerializeField] Item OintmentFromFlyAgaric;
    [SerializeField] Item NutritionalMedicine;
    [SerializeField] Item MedicineForMemory;
    [SerializeField] Item Powder;
    [SerializeField] Item StomachMedicine;
    [SerializeField] Item Dummy;

    private void Start()
    {

        parentRectTransform = this.gameObject.GetComponent<RectTransform>();

        int childCount = parentRectTransform.childCount;

        for (int i = 0; i < childCount; i++)
        {

                RectTransform childRectTransform = parentRectTransform.GetChild(i).GetComponent<RectTransform>();

                if (childRectTransform != null)
                {
                    point.Add(childRectTransform);
                    occupied.Add(false);
                    blocks.Add(null);
                }
            
        }
    }

    public Vector2 SetPosition(Block block)
    {
        for (int i = 0; i < point.Count; i++)
        {
            if (!occupied[i])
            {
                // ¬ставл€ем во все точки, кроме двух последних
                if (i < point.Count - 2)
                {
                    occupied[i] = true;
                    blocks[i] = block;
                    return point[i].anchoredPosition + parentRectTransform.anchoredPosition;
                }
                // ≈сли вызван AddPoin(), то разрешаем вставку на 1 больше
                else if (i < maxPoints)
                {
                    occupied[i] = true;
                    blocks[i] = block;
                    return point[i].anchoredPosition + parentRectTransform.anchoredPosition;
                }
            }
        }

        return Vector2.zero;
    }

    public void NotOccupied(int i)
    {
        if (!(i == -1))
        {
            occupied[i] = false;
            blocks[i] = null;
        }
    }

    public int SetId()
    {
        for (int i = 0; i < point.Count; i++)
        {
            if (!occupied[i])
            {
                return i;
            }
        }
        return -1;
    }


    public int RemoveObject(int i)
    {
        if(!(i == -1))
        {
            occupied[i] = false;
            blocks[i] = null;

        }
        return -1;
    }

    public void Prepare()
    {
        if (blocks[0].actions == Block.Actions.Cut &&
            blocks[0].installedItem.itemType == ItemType.FlyAgaric &&
            blocks[1].actions == Block.Actions.Heat &&
            blocks[2].actions == Block.Actions.TalkAbout &&
            blocks[3].actions == Block.Actions.Mix &&
            blocks[3].installedItem.itemType == ItemType.BaseForOintment &&
            blocks[4].actions == Block.Actions.Pack &&
            blocks[4].installedItem.itemType == ItemType.Pot)
        {
            // получаем мазь из мухомора
            Debug.Log("// получаем мазь из мухомора");
            RemuveRemoveItems();
            InventoryManager.instance.AddItem(OintmentFromFlyAgaric);
        }
        else if(blocks[0].actions == Block.Actions.TalkAbout &&
            blocks[0].installedItem.itemType == ItemType.Chanterelle &&
            blocks[1].actions == Block.Actions.Heat &&
            blocks[2].actions == Block.Actions.Mix &&
            blocks[2].installedItem.itemType == ItemType.Water &&
            blocks[3].actions == Block.Actions.Pack &&
            blocks[3].installedItem.itemType == ItemType.Pot)
        {
            // получаем питательную микстуру
            Debug.Log("// получаем питательную микстуру");
            RemuveRemoveItems();
            InventoryManager.instance.AddItem(NutritionalMedicine);
        }
        else if (blocks[0].actions == Block.Actions.Heat &&
            blocks[0].installedItem.itemType == ItemType.VioletWebcap &&
            blocks[1].actions == Block.Actions.TalkAbout &&
            blocks[2].actions == Block.Actions.Mix &&
            blocks[2].installedItem.itemType == ItemType.Water &&
            blocks[3].actions == Block.Actions.Pack &&
            blocks[3].installedItem.itemType == ItemType.Pot)
        {
            // получаем микстуру дл€ пам€ти
            Debug.Log("// получаем микстуру дл€ пам€ти");
            RemuveRemoveItems();
            InventoryManager.instance.AddItem(MedicineForMemory);
        }
        else if (blocks[0].actions == Block.Actions.TalkAbout &&
            blocks[0].installedItem.itemType == ItemType.GlossyGloss &&
            blocks[1].actions == Block.Actions.TalkAbout &&
            blocks[2].actions == Block.Actions.Pack &&
            blocks[2].installedItem.itemType == ItemType.Pot)
        {
            // получаем присыпку
            Debug.Log(" // получаем присыпку");
            RemuveRemoveItems();
            InventoryManager.instance.AddItem(Powder);
        }
        else if (blocks[0].actions == Block.Actions.Cut &&
            blocks[0].installedItem.itemType == ItemType.GlossyGloss &&
            blocks[1].actions == Block.Actions.Mix &&
            blocks[1].installedItem.itemType == ItemType.Water &&
            blocks[2].actions == Block.Actions.Heat &&
            blocks[3].actions == Block.Actions.Pack &&
            blocks[3].installedItem.itemType == ItemType.Pot)
        {
            // получаем микстуру дл€ желутка
            Debug.Log("// получаем микстуру дл€ желутка");
            RemuveRemoveItems();
            InventoryManager.instance.AddItem(StomachMedicine);
        }
        else
        {
            if (blocks[0].installedItem != null)
            {
                // получаем ѕустышку
                Debug.Log("// получаем ѕустышку");
                RemuveRemoveItems();
                InventoryManager.instance.AddItem(Dummy);
            }
        }
        Debug.Log(blocks[0].installedItem);
    }

    private void RemuveRemoveItems()
    {
        for (int i = blocks.Count - 1; i >= 0; i--)
        {
            if (blocks[i] != null && blocks[i].installedItem != null)
            {
                InventoryManager.instance.RemoveItem(blocks[i].installedItem.itemType);

            }
        }
        dronMenu.CloseMenu();
    }

    public void AddPoint()
    {
        if (maxPoints < point.Count)
        {
            maxPoints++;
        }
    }
}