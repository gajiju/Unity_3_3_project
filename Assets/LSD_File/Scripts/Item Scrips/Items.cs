using System;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;

    private SphereCollider itemCollider;

    private void Awake()
    {
        itemCollider = GetComponent<SphereCollider>();

        if (gameObject != null)
        {
            Invoke("ActiveItemCollider", 1f);
        }
    }

    /// <summary>
    /// 아이템 드랍 이후 위 1(Invoke)초 후 콜라이더 활성화 메소드
    /// </summary>
    private void ActiveItemCollider()
    {
        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }
    }
    /// <summary>
    /// 아이템 픽업 관한 코드
    /// </summary>
    private void OnTriggerEnter(Collider collision)
    {
        // 이벤트 Player 태그 충돌 감지
        if (collision.gameObject.tag == "Player")
        {
            ItemPickup();
        }
    }

    private void ItemPickup()
    {
        // 아이템 픽업시 효과
        Debug.Log("아이템을 주웠다.");
    }
}
