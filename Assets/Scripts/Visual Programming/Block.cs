using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Panel panel;
    [SerializeField] private GameObject parameterSlot;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPosition;
    private Vector2 localPointerPosition;
    [SerializeField] private string desiredTag = "Panel";
    private Block block;

    private int id = -1;
    public Actions actions;
    public Item installedItem;

    private bool isDragging = false;

    public Item GetItem()
    {
        return installedItem;
    }

    public void SetItem(Item item)
    {
        installedItem = item;
    }

    void Start()
    {

        block = GetComponent<Block>();
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        startPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            StartPosition();
        }
        else
        {
            isDragging = true;
            canvasGroup.blocksRaycasts = false;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPointerPosition
            );
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint
            );
            rectTransform.anchoredPosition = localPoint - localPointerPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag(desiredTag))
        {
            panel.NotOccupied(id);
            id = panel.SetId();

            if(id != 0 && actions != Actions.Pack && actions != Actions.Mix)
            {
                parameterSlot.SetActive(false);
            }

            rectTransform.anchoredPosition = panel.SetPosition(block);
            if (rectTransform.anchoredPosition == Vector2.zero)
            {
                StartPosition();
            }
        }
        else
        {
            StartPosition();
        }
    }

    public Vector2 GetStartPosition()
    {
        return startPosition;
    }

    private void StartPosition()
    {
        id = panel.RemoveObject(id);
        rectTransform.anchoredPosition = startPosition;
        parameterSlot.SetActive(true);
    }

    private void OnDisable()
    {
        ClearAll();
    }
    void ClearAll()
    {
        StartPosition();
        panel.NotOccupied(id);
    }


    public enum Actions
    {
        Mix,
        Cut,
        TalkAbout,
        Heat,
        Pack
    }
}


