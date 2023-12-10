using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalAbilities : Hint
{
    PlayerMove player;
    [SerializeField] Item item;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.timeScale == 1)
        {
            if (other.CompareTag("Player"))
            {
                HintConclusion("ֽאזלטעו E");
                if (Input.GetKey(KeyCode.E))
                {
                    Item newItem = Instantiate(item);
                    newItem.itemType = item.itemType;
                    switch (newItem.itemType)
                    {
                        case ItemType.DoubleJamp:
                            player.SetMaxJumps(2);
                            break;
                        case ItemType.Dash:
                            player.SetDash(true);
                            break;
                        case ItemType.SlowLanding:
                            player.SetSlowLanding(true);
                            break;
                        default:
                            break;
                    }
                    Destroy(this.gameObject);
                }
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (Time.timeScale == 1)
        {
            if (other.CompareTag("Player"))
            {
                HideHint();

            }
        }
    }
}
