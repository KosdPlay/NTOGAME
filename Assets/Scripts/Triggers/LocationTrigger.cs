using UnityEngine;
using UnityEngine.UI;

public class LocationTrigger : MonoBehaviour
{
    [SerializeField] Diary diaryScript;

    [SerializeField] Sprite ImageLocation;
    [SerializeField] string headerLocations;
    [SerializeField] string descriptionLocations;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            diaryScript.HandleLocationTrigger(ImageLocation, headerLocations, descriptionLocations);
            Destroy(this);
        }
    }
}