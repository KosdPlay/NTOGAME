using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private bool isSpawn = false;

    private void Start()
    {

        Instantiate(prefab, transform.position, Quaternion.identity);

    }

    private void Update()
    {
        spawn();

    }

    public void spawn()
    {
        if (ChangeDay.instance.isEndDay == true && isSpawn == false)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            isSpawn = true;
            Debug.Log("kjfjhegralijghbksd,fjhghsdfsgfhjhgf");
        }
        else if (ChangeDay.instance.isEndDay == false)
        {
            isSpawn = false;
        }
    }
}
