using System;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultStats", menuName = "TopDownController/Stats/Default", order = 0)]
[Serializable]
public class CharacterStatsSO_JY : ScriptableObject
{
    public StatsChangeType statsChangeType;

    [Header("CharacterStats Info")]
    public string _Name; // 이름
    public float _MaxHp; // 최대 체력
    public float _CurrentHp; // 현재 체력
    public float _MaxSp; // 최대 스테미너
    public float _CurrentSp; // 현재 스테미너
    public float _Atk; // 공격력
    public float _AS; // 공격속도
    public float _MS; // 이동속도

    public GameObject playerPrefab; //플레이어 프리팹
}
