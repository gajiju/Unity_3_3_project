using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CurrentStats = new CharacterStats ();
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.MaxHp = baseStats.MaxHp;
        CurrentStats.MaxSp = baseStats.MaxSp;
        CurrentStats.MS = baseStats.MS;
    }
}
