using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private int money = 0;
    public GameObject portal;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddMoney()
    {
        ++money;
    }

    public void SubMoney()
    {
        --money;

        if (money <= 0 )
        {
            OpenPortal();
        }
    }

    private void OpenPortal()
    {
        portal.SetActive(true);
    }
}
