using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpSystem_JY : MonoBehaviour
{
    [SerializeField] private float HpChangeDelay = .5f;

    private PlayerStatsHandler_JY _statsHandler;

    public Image uiBar;

    public float CurrentHp { get; private set; }

    public float MaxHp => _statsHandler.CurrentStats._MaxHp;

    private void Awake()
    {
        _statsHandler = GetComponent<PlayerStatsHandler_JY>();
    }

    private void Start()
    {
        CurrentHp = _statsHandler.CurrentStats._CurrentHp;
    }

    private void Update()
    {

        uiBar.fillAmount = GetPercentage();
    }

    public float GetPercentage()
    {
        return CurrentHp / MaxHp;
    }
}

