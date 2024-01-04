using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStats_JY;

public class PlayerStatsHandler_JY : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStats { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        //AttackSO attackSO = null;
        //if (baseStats.attackSO != null)
        //{
        //    attackSO = Instantiate(baseStats.attackSO);
        //}

        //CurrentStates = new CharacterStats { attackSO = attackSO };
        // TODO
        CurrentStats.MaxHp = baseStats.MaxHp;
        CurrentStats.MaxSp = baseStats.MaxSp;
        CurrentStats.MS = baseStats.MS;

    }
}
