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

    public string _Name = "�߻�"; // �̸�
    public float _MaxHp = 100; // �ִ� ü��
    public float _CurrentHp = 100; // ���� ü��
    public float _MaxSp = 100; // �ִ� ���׹̳�
    public float _CurrentSp = 100; // ���� ���׹̳�
    public float _Atk = 20f; // ���ݷ�
    public float _AS = 0.5f; // ���ݼӵ�
    public float _MS = 5; // �̵��ӵ�
}
