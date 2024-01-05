using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatsHandler_JY : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO_JY statsSO;
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStats {get; private set;}
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdatebaseStats();
        UpdateCharacterStats();
    }
    private void UpdatebaseStats()
    {
        baseStats._Name = statsSO._Name;
        baseStats._MaxHp = statsSO._MaxHp;
        baseStats._CurrentHp = statsSO._CurrentHp;
        baseStats._MaxSp = statsSO._MaxSp;
        baseStats._CurrentSp = statsSO._CurrentSp;
        baseStats._Atk = statsSO._Atk;
        baseStats._AS = statsSO._AS;
        baseStats._MS = statsSO._MS;
    }

    private void UpdateCharacterStats()
    {
        CurrentStats = new CharacterStats();
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats._Name = baseStats._Name;
        CurrentStats._MaxHp = baseStats._MaxHp;
        CurrentStats._CurrentHp = baseStats._CurrentHp;
        CurrentStats._MaxSp = baseStats._MaxSp;
        CurrentStats._CurrentSp = baseStats._CurrentSp;
        CurrentStats._Atk = baseStats._Atk;
        CurrentStats._AS = baseStats._AS;
        CurrentStats._MS = baseStats._MS;
    }
}
