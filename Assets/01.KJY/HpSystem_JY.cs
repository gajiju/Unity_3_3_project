using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpSystem_JY : MonoBehaviour
{
    [SerializeField] private float HpChangeDelay = .5f;

    private PlayerStatsHandler_JY _statsHandler;
    private float _timeSinceLastChange = float.MaxValue;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;
    public Image uiBar;


    public float MaxHp => _statsHandler.CurrentStats._MaxHp;

    private void Awake()
    {
        _statsHandler = GetComponent<PlayerStatsHandler_JY>();
    }


    private void Update()
    {
        if (_timeSinceLastChange < HpChangeDelay)
        {
            _timeSinceLastChange += Time.deltaTime;
            if (_timeSinceLastChange >= HpChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
            }
        }
        uiBar.fillAmount = GetPercentage();
    }

    //public bool ChangeHealth(float change)
    //{
    //    if (change == 0 || _timeSinceLastChange < HpChangeDelay)
    //    {
    //        return false;
    //    }

    //    _timeSinceLastChange = 0f;
    //    CurrentHp += change;
    //    CurrentHp = CurrentHp > MaxHp ? MaxHp : CurrentHp;
    //    CurrentHp = CurrentHp < 0 ? 0 : CurrentHp;

    //    if (change > 0)
    //    {
    //        OnHeal?.Invoke();
    //    }
    //    else
    //    {
    //        OnDamage?.Invoke();
    //    }

    //    if (CurrentHp <= 0f)
    //    {
    //        CallDeath();
    //    }

    //    return true;
    //}

    //private void CallDeath()
    //{
    //    OnDeath?.Invoke();
    //}
    public float GetPercentage()
    {
        return _statsHandler.CurrentStats._CurrentHp / MaxHp;
    }
}

