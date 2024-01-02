using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName; // 아이템 이름
    
    [Serializable] // 직렬화 (byte)
    public struct Value
    {
        /* name 에 들어갈 값
         CurHP_Up, CurHP_Down,
         Power_Up, Power_Down,
         MoveSpeed_Up, MoveSpeed_Down */
        public string name; // 능력치 이름

        /* name 에 들어갈 값
        +값 혹은 -값 */
        public int value; // 능력치 값
    }

    public List<Value> stats = new List<Value>();

    public GameObject gameObject; // 이 아이템 프리팹
}
