using UnityEngine;
using static PlayerStats_Kys;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    private PlayerStats_Kys playerStats;
    private GameObject player;
    private float buffTime = 0f;

    private Collider itemCollider;

    private void Awake()
    {
        itemCollider = GetComponent<Collider>();
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats_Kys>();

        if (gameObject != null)
        {
            Invoke("ActiveItemCollider", 1f);
        }
    }
    private void Update()
    {
        buffTime -= Time.deltaTime;
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
            if (!collision.isTrigger)
            {
                ItemPickup();
            }
        }
    }

    private void ItemPickup()
    {
        // 아이템 픽업시 능력치 증가 효과 로직
        /* case 에 들어갈 string 값
        Player_CurrentHp_Up 현재체력 증가
        Player_MaxHp_Up 최대체력 증가
        Player_CurrentSp_Up 현재스태미나 증가
        Player_MaxSp_Up 최대스태미나 증가
        Player_Atk_Up 공격력 증가
        Player_AS_Up 공격속도 증가
        Player_MS_Up 이동속도 증가
        */
        var item = itemSO;
        switch (item.itemName)
        {
            case "Player_CurrentHp_Up":
                playerStats.user_date.CurrentStats._CurrentHp += item.stats[0].value;
                Destroy(gameObject);
                break;
            case "Player_CurrentSp_Up":
                playerStats.user_date.CurrentStats._CurrentSp += item.stats[0].value;
                Destroy(gameObject);
                break;
            case "Player_Atk_Up":
                playerStats.user_date.CurrentStats._Atk += item.stats[0].value;
                buffTime = item.stats[0].buffTime;
                if (buffTime < 0)
                {
                    playerStats.user_date.CurrentStats._Atk -= item.stats[0].value;
                    Destroy(gameObject);
                }
                break;
            case "Player_AS_Up":
                playerStats.user_date.CurrentStats._AS += item.stats[0].value;
                buffTime = item.stats[0].buffTime;
                if (buffTime < 0)
                {
                    playerStats.user_date.CurrentStats._AS -= item.stats[0].value;
                    Destroy(gameObject);
                }
                break;
            case "Player_MS_Up":
                playerStats.user_date.CurrentStats._MS += item.stats[0].value;
                buffTime = item.stats[0].buffTime;
                if (buffTime < 0)
                {
                    playerStats.user_date.CurrentStats._MS -= item.stats[0].value;
                    Destroy(gameObject);
                }
                break;
        }
    }
}
