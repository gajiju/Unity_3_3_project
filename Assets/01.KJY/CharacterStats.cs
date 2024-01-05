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

    public string _Name; // �̸�
    public float _MaxHp; // �ִ� ü��
    public float _CurrentHp; // ���� ü��
    public float _MaxSp; // �ִ� ���׹̳�
    public float _CurrentSp; // ���� ���׹̳�
    public float _Atk; // ���ݷ�
    public float _AS; // ���ݼӵ�
    public float _MS; // �̵��ӵ�
}
