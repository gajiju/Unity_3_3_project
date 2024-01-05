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
        [Range(1f, 200f)] public float MaxHp; //최대체력
        [Range(1f, 200f)] public float MaxSp; //최대스태미나
        [Range(1f, 20f)] public float MS; //이동속도
}
