using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    [SerializeField] Diary diaryScript;

    [SerializeField] Sprite ImageLocation;
    [SerializeField] string headerLocations;
    [SerializeField] string descriptionLocations;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            diaryScript.HandleStoryTrigger(ImageLocation, headerLocations, descriptionLocations);
            Destroy(this);
        }
    }
}
