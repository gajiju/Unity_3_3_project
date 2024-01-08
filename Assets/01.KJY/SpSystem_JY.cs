using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpSystem_JY : MonoBehaviour
{
    private PlayerStatsHandler_JY _statsHandler;

    public Image uiBar;
    private float recoveryRate = 5f;
    private float UseWhirlwind = 30f;
    private float UseSplint = 15f;

    private float MaxSp => _statsHandler.CurrentStats._MaxSp;

    private float recoveryInterval = 1f;

    private void Awake()
    {
        _statsHandler = GetComponent<PlayerStatsHandler_JY>();
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
        if (_statsHandler.CurrentStats._CurrentSp < MaxSp)
        {
            RecoverStamina();
        }
    }
    public void RecoverStamina()
    {
        if (_statsHandler.CurrentStats._CurrentSp < MaxSp)
        {
            float recoveryAmount = recoveryRate * Time.deltaTime;
            _statsHandler.CurrentStats._CurrentSp = Mathf.Min(_statsHandler.CurrentStats._CurrentSp + recoveryAmount, MaxSp);
        }
    }
    public bool CanUseWhirlwind()
    {
        return _statsHandler.CurrentStats._CurrentSp >= UseWhirlwind;
    }
    public bool CanUseSplint()
    {
        return _statsHandler.CurrentStats._CurrentSp >= 10f;
    }


    public bool UseStaminaForWhirlwind()
    {
        if (CanUseWhirlwind())
        {
            _statsHandler.CurrentStats._CurrentSp -= UseWhirlwind * Time.deltaTime;
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
            _statsHandler.CurrentStats._CurrentSp -= UseSplint * Time.deltaTime;
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetPercentage()
    {
        return _statsHandler.CurrentStats._CurrentSp / MaxSp;
    }
}
