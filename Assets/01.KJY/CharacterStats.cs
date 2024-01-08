using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}
[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;

    public string _Name = "삐삐"; // 이름
    public float _MaxHp = 100; // 최대 체력
    public float _CurrentHp = 100; // 현재 체력
    public float _MaxSp = 100; // 최대 스테미너
    public float _CurrentSp = 100; // 현재 스테미너
    public float _Atk = 20f; // 공격력
    public float _AS = 0.5f; // 공격속도
    public float _MS = 5; // 이동속도
}
