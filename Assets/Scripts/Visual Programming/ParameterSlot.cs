using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterSlot : MonoBehaviour
{

    [SerializeField] private RectTransform parentRectTransform;
    [SerializeField] private RectTransform point;
    [SerializeField] private bool occupied;
    [SerializeField] private Item installedItem;
    [SerializeField] private Block block;



    private void Start()
    {


        point = this.gameObject.GetComponent<RectTransform>();
        occupied = false;
    }

    public Vector2 SetPosition(Item item)
    {

        if (!occupied)
        {
            occupied = true;
            installedItem = item;
            block.SetItem(installedItem);
            return 2.5f * point.anchoredPosition + parentRectTransform.anchoredPosition;
        }

        return Vector2.zero;

    }

    public bool IsStartingPosition()
    {
        if(block.GetStartPosition() == parentRectTransform.anchoredPosition)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveObject( Item item)
    {

        occupied = false;
        installedItem = null;
        block.SetItem(installedItem);
    }

    private void OnDisable()
    {
        ClearAll();
    }
    void ClearAll()
    {
        occupied = false;
        installedItem = null;
        block.SetItem(installedItem);
    }
}