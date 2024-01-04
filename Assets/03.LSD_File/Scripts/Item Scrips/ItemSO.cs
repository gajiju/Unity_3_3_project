using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemDefault", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("ItemData")]
    public string itemName; // ������ �̸�
    
    [Serializable] // ����ȭ (byte)
    public struct Value
    {
        /* name �� �� ��
        Player_CurrentHp ����ü��
        Player_MaxHp �ִ�ü��
        Player_CurrentSp ���罺�¹̳�
        Player_MaxSp �ִ뽺�¹̳�
        Player_Atk ���ݷ�
        Player_AS ���ݼӵ�
        Player_MS �̵��ӵ�
        */
        public string name; // �ɷ�ġ �̸�

        /* name �� �� ��
        +�� Ȥ�� -�� */
        public float value; // �ɷ�ġ ��
        public float buffTime; // ���� �ð� 1f = 1��, 0f = �ٷ� ����
    }

    public List<Value> stats = new List<Value>();

    public GameObject prefab; // �� ������ ������
}
