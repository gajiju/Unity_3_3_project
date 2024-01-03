using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDrop", menuName = "Item/ItemData/ItemDrop", order = 1)]
public class ItemDropSO : ScriptableObject
{
    [Serializable]
    public class Items
    {
        public ItemSO item; // ItemSO ������ �ν����� â���� �Ҵ�
        public int weight;
        // �ش� �������� Ȯ�� ���� �������� Ȯ�� ����
        // ���÷� 3���� �������� weight���� 1,1,1 �̸� 33.3% ������ Ȯ���� 1�� ������ ���
    }

    // ������ ��� �ڽ� �ȿ� ���� �����۵� �Ҵ�
    public List<Items> items = new List<Items>();

    protected ItemSO PickItem()
    {
        int sum = 0;

        foreach (var item in items)
        {
            sum += item.weight; // ����Ʈ�� ������ ������ŭ weight ���� sum�� ����
        }

        float rnd = UnityEngine.Random.Range(0, sum); // ����Ƽ ���� ���� + ������ Ȯ��

        /* 0�� �迭�� ������ ���� �����ؼ� item.weight ���� rnd ���� ���ٸ� 0�� �������� ����
        �ƴ϶�� rnd -= item.weight �ؼ� ���� 1�� item.weight ���� rnd ���� ���ٸ� 1�� ��������....
        �׷��� ����Ʈ�� ����ִ� ��� �������� item.weight ���� �����Ѵ�. */
        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];
            if (item.weight > rnd)
            {
                return items[i].item;
            }
            else
            {
                rnd -= item.weight;
            }
        }
        return null;
    }

    /// <summary>
    /// PickItem()�� ���ϰ��� ������ �ش� ��ġ�� item.prefab Ŭ�� ����
    /// </summary>
    /// <param name="pos"></param>
    public void ItemDrop(Vector3 pos)
    {
        var item = PickItem();
        if (item == null)
        {
            return;
        }
        Instantiate(item.prefab, pos, Quaternion.identity);
    }
}
