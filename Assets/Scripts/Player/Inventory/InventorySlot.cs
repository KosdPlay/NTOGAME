using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    Transform spawnPoint;
    [SerializeField] GameObject[] items;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panelDescription;

    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image itemImage;

    [SerializeField] private Item currentItem;
    private bool isClicked;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SetPanelActive(false);
        SetPanelDescriptionActive(false);
    }

    // устанавливается значение для окон в инвентаре

    private void SetPanelActive(bool active)
    {
        panel.SetActive(active);
    }

    private void SetPanelDescriptionActive(bool active)
    {
        panelDescription.SetActive(active);
    }

    // Все вкладки в инвентаре приходят в начальное положение

    private void ClearAll()
    {
        SetPanelActive(false);
        SetPanelDescriptionActive(false);
        isClicked = false;
    }

    private void OnDisable()
    {
        ClearAll();
    }


    // Установливаются значения

    public void UpdateSlot(Item item)
    {
        currentItem = item;

        itemNameText.text = item?.itemName ?? "";
        itemImage.sprite = item?.itemImage;
    }

    // Включение и выключение окон у предмета

    private void OnPointerEnter()
    {
        if (currentItem != null)
        {
            SetPanelActive(true);
            isClicked = true;
            SetPanelDescriptionActive(false);
        }
    }

    private void OnPointerExit()
    {
        SetPanelActive(false);
        isClicked = false;
        SetPanelDescriptionActive(false);
    }

    // Кнопки

    public void Click()
    {
        if (!isClicked)
        {
            OnPointerEnter();
        }
        else
        {
            OnPointerExit();
        }
    }


    public void Description()
    {
        description.text = currentItem?.itemDescription ?? "";
        SetPanelActive(false);
        isClicked = true;
        SetPanelDescriptionActive(true);
    }

    public void DeleteItem()
    {
        if (currentItem != null)
        {
            InventoryManager.instance.RemoveItem(currentItem.itemType);
        }
        ClearAll();
    }

    public void DropItem()
    {
        if (currentItem != null)
        {
            switch (currentItem.itemType)
            {
                case ItemType.FlyAgaric:
                    Instantiate(items[0], new Vector3(spawnPoint.position.x, spawnPoint.position.y-1, spawnPoint.position.z), Quaternion.identity);
                    break;
                case ItemType.GlossyGloss:
                    Instantiate(items[1], new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1, spawnPoint.position.z), Quaternion.identity);
                    break;
                case ItemType.Chanterelle:
                    Instantiate(items[2], new Vector3(spawnPoint.position.x, spawnPoint.position.y - 1, spawnPoint.position.z), Quaternion.identity);
                    break;
                default:
                    break;
            }
            InventoryManager.instance.RemoveItem(currentItem.itemType);
        }
        ClearAll();
    }
}
