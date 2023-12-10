using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hint : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI hintText;

    protected void HintConclusion(string hint)
    {
        hintText.text = hint;
    }

    protected void HideHint()
    {
        hintText.text = "";
    }

    void Awake()
    {
        GameObject[] hintTexts = GameObject.FindGameObjectsWithTag("hintText");

        if (hintTexts.Length > 0)
        {
            hintText = hintTexts[0].GetComponent<TextMeshProUGUI>();
        }
    }
}
