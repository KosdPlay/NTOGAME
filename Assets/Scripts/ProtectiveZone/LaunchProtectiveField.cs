using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProtectiveField : MonoBehaviour
{
    [SerializeField] GameObject protectiveZone;
    public static LaunchProtectiveField instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        protectiveZone.SetActive(false);

    }

    public void EnableProtectiveZone()
    {
        protectiveZone.SetActive(true);
    }


}
