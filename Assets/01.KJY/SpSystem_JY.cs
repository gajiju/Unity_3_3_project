using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpSystem_JY : MonoBehaviour
{
    private PlayerStatsHandler_JY _statsHandler;
    private PlayerStats_Kys _playerstats;

    public Image uiBar;
    public float recoveryRate = 5f;
    public float UseWhirlwind = 20f;
    public float UseSplint = 1f;

    public float CurrentSp {  get; private set; }
    public float MaxSp => _statsHandler.CurrentStats._MaxSp;

    public float recoveryInterval = 1f;

    private void Awake()
    {
        _statsHandler = GetComponent<PlayerStatsHandler_JY>();
        _playerstats = GetComponent<PlayerStats_Kys>();
    }

    void Start()
    {
        CurrentSp = _statsHandler.CurrentStats._CurrentSp;
    }

    void Update()
    {
        UpdateStamina();
        if (uiBar != null) // UI 바가 할당되어 있는 경우에만 업데이트
            uiBar.fillAmount = GetPercentage();

        if (Input.GetMouseButton(1) && CanUseWhirlwind())
        {
            UseStaminaForWhirlwind();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanUseSplint())
        {
            UseStaminaForSplint();
        }
    }

    private void UpdateStamina()
    {
        if (CurrentSp < MaxSp)
        {
            float recoveryAmount = recoveryRate * Time.deltaTime;
            CurrentSp = Mathf.Min(CurrentSp + recoveryAmount, MaxSp);
        }
    }
    public void RecoverStamina()
    {
        if (CurrentSp < MaxSp)
        {
            float recoveryAmount = recoveryRate * Time.deltaTime;
            CurrentSp = Mathf.Min(CurrentSp + recoveryAmount, MaxSp);
        }
    }
    public bool CanUseWhirlwind()
    {
        return CurrentSp >= UseWhirlwind;
    }
    public bool CanUseSplint()
    {
        return CurrentSp >= 10f;
    }


    public bool UseStaminaForWhirlwind()
    {
        if (CanUseWhirlwind())
        {
            CurrentSp -= UseWhirlwind;
            //_playerstats.OnWhirlwind();
            return true;
        }
        else
        {

            return false;
        }
    }
    public bool UseStaminaForSplint()
    {
        if (CanUseSplint())
        {
            CurrentSp -= UseSplint;
            _playerstats.OnSplint();
            return true;
        }
        else
        {

            return false;
        }
    }

    public float GetPercentage()
    {
        return CurrentSp / MaxSp;
    }
}
