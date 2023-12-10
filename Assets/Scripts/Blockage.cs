using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    [SerializeField] End end;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            end.FarewellWords(2);
        }
    }
}
