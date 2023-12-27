using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryTrigger : MonoBehaviour
{
    [SerializeField] Diary diaryScript;

    [SerializeField] Sprite ImageLocation;
    [SerializeField] string headerLocations;
    [SerializeField] string descriptionLocations;
    [SerializeField] string enemyName;

    private void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Diary");
        foreach (GameObject go in gos)
            diaryScript = (go.GetComponent<Diary>());
    }

    private void OnDisable()
    {
            diaryScript.HandleBestiaryTrigger(ImageLocation, headerLocations, descriptionLocations, enemyName);
    }
}
