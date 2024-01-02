using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName; // ������ �̸�
    
    [Serializable] // ����ȭ (byte)
    public struct Value
    {
        /* name �� �� ��
         CurHP_Up, CurHP_Down,
         Power_Up, Power_Down,
         MoveSpeed_Up, MoveSpeed_Down */
        public string name; // �ɷ�ġ �̸�

        /* name �� �� ��
        +�� Ȥ�� -�� */
        public int value; // �ɷ�ġ ��
    }

    public List<Value> stats = new List<Value>();

    public GameObject gameObject; // �� ������ ������
}
