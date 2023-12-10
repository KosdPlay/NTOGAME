using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterStorage : MonoBehaviour
{
    [SerializeField] private RectTransform panelRectTransform;

    [SerializeField] private int countFlyAgaric = 0;
    [SerializeField] GameObject flyAgaric;
    [SerializeField] RectTransform flyAgaricPoint;
    [SerializeField] List<GameObject> flyAgarics = new List<GameObject>();

    [SerializeField] private int countChanterelle = 0;
    [SerializeField] GameObject chanterelle;
    [SerializeField] RectTransform chanterellePoint;
    [SerializeField] List<GameObject> chanterelles = new List<GameObject>();

    [SerializeField] private int countWater = 0;
    [SerializeField] GameObject water;
    [SerializeField] RectTransform waterPoint;
    [SerializeField] List<GameObject> waters = new List<GameObject>();

    [SerializeField] private int countBaseForOintment = 0;
    [SerializeField] GameObject baseForOintment;
    [SerializeField] RectTransform baseForOintmentPoint;
    [SerializeField] List<GameObject> baseForOintments = new List<GameObject>();

    [SerializeField] private int countPot = 0;
    [SerializeField] GameObject pot;
    [SerializeField] RectTransform potPoint;
    [SerializeField] List<GameObject> pots = new List<GameObject>();

    [SerializeField] private int countVioletWebcap = 0;
    [SerializeField] GameObject violetWebcap;
    [SerializeField] RectTransform violetWebcapPoint;
    [SerializeField] List<GameObject> VioletWebcaps = new List<GameObject>();

    [SerializeField] private int countGlossyGloss = 0;
    [SerializeField] GameObject glossyGloss;
    [SerializeField] RectTransform glossyGlossPoint;
    [SerializeField] List<GameObject> glossyGlosses = new List<GameObject>();


    void OnEnable()
    {

        countFlyAgaric = InventoryManager.instance.GetItemCount(ItemType.FlyAgaric);
        for(int i = 0; i < countFlyAgaric; i++)
        {
            flyAgarics.Add(Instantiate(flyAgaric, flyAgaricPoint.anchoredPosition + panelRectTransform.anchoredPosition, Quaternion.identity));
            flyAgarics[i].transform.SetParent(this.transform, false);
        }

        countChanterelle = InventoryManager.instance.GetItemCount(ItemType.Chanterelle);
        for (int i = 0; i < countChanterelle; i++)
        {
            chanterelles.Add(Instantiate(chanterelle, chanterellePoint.anchoredPosition + panelRectTransform.anchoredPosition, Quaternion.identity));
            chanterelles[i].transform.SetParent(this.transform, false);
        }

        countWater = InventoryManager.instance.GetItemCount(ItemType.Water);
        for (int i = 0; i < countWater; i++)
        {
            waters.Add(Instantiate(water, waterPoint.anchoredPosition + panelRectTransform.anchoredPosition, Quaternion.identity));
            waters[i].transform.SetParent(this.transform, false);
        }

        countBaseForOintment = InventoryManager.instance.GetItemCount(ItemType.BaseForOintment);
        for (int i = 0; i < countBaseForOintment; i++)
        {
            baseForOintments.Add(Instantiate(baseForOintment, baseForOintmentPoint.anchoredPosition + panelRectTransform.anchoredPosition, Quaternion.identity));
            baseForOintments[i].transform.SetParent(this.transform, false);
        }

        countPot = InventoryManager.instance.GetItemCount(ItemType.Pot);
        for (int i = 0; i < countPot; i++)
        {
            pots.Add(Instantiate(pot, potPoint.anchoredPosition + panelRectTransform.anchoredPosition, Quaternion.identity));
            pots[i].transform.SetParent(this.transform, false);
        }

        countVioletWebcap = InventoryManager.instance.GetItemCount(ItemType.VioletWebcap);
        for (int i = 0; i < countVioletWebcap; i++)
        {
            VioletWebcaps.Add(Instantiate(violetWebcap, violetWebcapPoint.anchoredPosition + panelRectTransform.anchoredPosition, Quaternion.identity));
            VioletWebcaps[i].transform.SetParent(this.transform, false);
        }

        countGlossyGloss = InventoryManager.instance.GetItemCount(ItemType.GlossyGloss);
        for (int i = 0; i < countGlossyGloss; i++)
        {
            glossyGlosses.Add(Instantiate(glossyGloss, glossyGlossPoint.anchoredPosition + panelRectTransform.anchoredPosition, Quaternion.identity));
            glossyGlosses[i].transform.SetParent(this.transform, false);
        }
    }

    private void OnDisable()
    {
        DisableFlyAgaric();
        DisableChanterelle();
        DisableWater();
        DisableBaseForOintment();
        DisablePot();
        DisableVioletWebcap();
        DisableGlossyGloss();
    }

    private void DisableFlyAgaric()
    {
        for (int i = 0; i < flyAgarics.Count; i++)
        {
            Destroy(flyAgarics[i]);
        }
        countFlyAgaric = 0;
        flyAgarics.Clear();
    }

    private void DisableChanterelle()
    {
        for (int i = 0; i < chanterelles.Count; i++)
        {
            Destroy(chanterelles[i]);
        }
        countChanterelle = 0;
        chanterelles.Clear();
    }

    private void DisableWater()
    {
        for (int i = 0; i < waters.Count; i++)
        {
            Destroy(waters[i]);
        }
        countWater = 0;
        waters.Clear();
    }

    private void DisableBaseForOintment()
    {
        for (int i = 0; i < baseForOintments.Count; i++)
        {
            Destroy(baseForOintments[i]);
        }
        countBaseForOintment = 0;
        baseForOintments.Clear();
    }

    private void DisablePot()
    {
        for (int i = 0; i < pots.Count; i++)
        {
            Destroy(pots[i]);
        }
        countPot = 0;
        pots.Clear();
    }

    private void DisableVioletWebcap()
    {
        for (int i = 0; i < VioletWebcaps.Count; i++)
        {
            Destroy(VioletWebcaps[i]);
        }
        countVioletWebcap = 0;
        VioletWebcaps.Clear();
    }

    private void DisableGlossyGloss()
    {
        for (int i = 0; i < glossyGlosses.Count; i++)
        {
            Destroy(glossyGlosses[i]);
        }
        countGlossyGloss = 0;
        glossyGlosses.Clear();
    }

}

