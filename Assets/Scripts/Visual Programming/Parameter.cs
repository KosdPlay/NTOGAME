using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Parameter : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image image;
    [SerializeField] private Item item;
    [SerializeField] private ParameterSlot parameterSlot;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPosition;
    private Vector2 localPointerPosition;
    [SerializeField] private string desiredTag = "ActiomBlock";
    

    private bool isDragging = false;

    void Start()
    {
        image = GetComponent<Image>();
        Debug.Log(item.itemType);
        Debug.Log(item.itemImage);
        image.sprite = item.itemImage;
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
        if(parameterSlot != null)
        {
            parameterSlot.RemoveObject(item);
        }

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
            parameterSlot = eventData.pointerEnter.GetComponent<ParameterSlot>();

            if(parameterSlot != null)
            {
                parameterSlot.RemoveObject(item);
                rectTransform.anchoredPosition = parameterSlot.SetPosition(item);
            }
            else
            {
                StartPosition();
            }
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

    private void StartPosition()
    {
        if (parameterSlot != null)
        {
            parameterSlot.RemoveObject(item);
        }

        rectTransform.anchoredPosition = startPosition;
    }

    private void OnDisable()
    {
        StartPosition();
    }


    private void Update()
    {
        if(parameterSlot != null)
        {
            if (parameterSlot.IsStartingPosition())
            {
                StartPosition();
                parameterSlot = null;
            }
        }
    }



}


