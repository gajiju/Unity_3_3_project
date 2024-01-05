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
        [Range(1f, 200f)] public float MaxHp; //�ִ�ü��
        [Range(1f, 200f)] public float MaxSp; //�ִ뽺�¹̳�
        [Range(1f, 20f)] public float MS; //�̵��ӵ�
}
