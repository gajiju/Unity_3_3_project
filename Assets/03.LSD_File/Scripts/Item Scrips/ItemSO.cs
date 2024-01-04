using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName; // 아이템 이름
    
    [Serializable] // 직렬화 (byte)
    public struct Value
    {
        /* name 에 들어갈 값
        Player_CurrentHp 현재체력
        Player_MaxHp 최대체력
        Player_CurrentSp 현재스태미나
        Player_MaxSp 최대스태미나
        Player_Atk 공격력
        Player_AS 공격속도
        Player_MS 이동속도
        */
        public string name; // 능력치 이름

        /* name 에 들어갈 값
        +값 혹은 -값 */
        public float value; // 능력치 값
        public float buffTime; // 버프 시간 1f = 1초, 0f = 바로 적용
    }

    public List<Value> stats = new List<Value>();

    public GameObject prefab; // 이 아이템 프리팹
}
