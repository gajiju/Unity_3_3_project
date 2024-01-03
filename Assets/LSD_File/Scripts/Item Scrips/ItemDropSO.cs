using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDrop", menuName = "Item/ItemData/ItemDrop", order = 1)]
public class ItemDropSO : ScriptableObject
{
    [Serializable]
    public class Items
    {
        public ItemSO item; // ItemSO 정보를 인스펙터 창에서 할당
        public int weight;
        // 해당 아이템의 확률 값이 높을수록 확률 증가
        // 예시로 3개의 아이템의 weight값이 1,1,1 이면 33.3% 정도의 확률로 1개 아이템 드랍
    }

    // 아이템 드롭 박스 안에 넣을 아이템들 할당
    public List<Items> items = new List<Items>();

    protected ItemSO PickItem()
    {
        int sum = 0;

        foreach (var item in items)
        {
            sum += item.weight; // 리스트의 아이템 개수만큼 weight 값을 sum에 저장
        }

        float rnd = UnityEngine.Random.Range(0, sum); // 유니티 엔진 랜덤 + 아이템 확률

        /* 0번 배열의 아이템 부터 시작해서 item.weight 값이 rnd 보다 높다면 0번 아이템을 리턴
        아니라면 rnd -= item.weight 해서 다음 1번 item.weight 값이 rnd 보다 높다면 1번 아이템을....
        그렇게 리스트에 담겨있는 모든 아이템의 item.weight 값을 대조한다. */
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
    /// PickItem()의 리턴값이 있으면 해당 위치에 item.prefab 클론 생성
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
