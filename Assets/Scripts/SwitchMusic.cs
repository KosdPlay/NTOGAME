using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip forest, rock, caves;
    [SerializeField] int id;
    [SerializeField] GameObject musicSwither;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (id)
            {
                case 0:
                    audioSource.clip = forest;
                    audioSource.Play();
                    break;
                case 1:
                    audioSource.clip = caves;
                    audioSource.Play();
                    break;
                case 2:
                    audioSource.clip = rock;
                    audioSource.Play();
                    break;
            }
            musicSwither.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
