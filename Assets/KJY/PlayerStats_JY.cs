using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats_JY : MonoBehaviour
{
    [Serializable]
    public class CharacterStats
    {
        [Range(1, 200)] public float MaxHp;
        [Range(1, 200)] public float MaxSp;
        [Range(1, 20)] public float MS;
    }
}
