using System;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultStats", menuName = "TopDownController/Stats/Default", order = 0)]
[Serializable]
public class CharacterStatsSO_JY : ScriptableObject
{
    public StatsChangeType statsChangeType;

    [Header("CharacterStats Info")]
    public string _Name; // �̸�
    public float _MaxHp; // �ִ� ü��
    public float _CurrentHp; // ���� ü��
    public float _MaxSp; // �ִ� ���׹̳�
    public float _CurrentSp; // ���� ���׹̳�
    public float _Atk; // ���ݷ�
    public float _AS; // ���ݼӵ�
    public float _MS; // �̵��ӵ�

    public GameObject playerPrefab; //�÷��̾� ������
}
