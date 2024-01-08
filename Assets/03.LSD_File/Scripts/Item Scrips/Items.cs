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
    /// ������ ��� ���� �� 1(Invoke)�� �� �ݶ��̴� Ȱ��ȭ �޼ҵ�
    /// </summary>
    private void ActiveItemCollider()
    {
        if (itemCollider != null)
        {
            itemCollider.enabled = true;
        }
    }
    /// <summary>
    /// ������ �Ⱦ� ���� �ڵ�
    /// </summary>
    private void OnTriggerEnter(Collider collision)
    {
        // �̺�Ʈ Player �±� �浹 ����
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
        // ������ �Ⱦ��� �ɷ�ġ ���� ȿ�� ����
        /* case �� �� string ��
        Player_CurrentHp_Up ����ü�� ����
        Player_MaxHp_Up �ִ�ü�� ����
        Player_CurrentSp_Up ���罺�¹̳� ����
        Player_MaxSp_Up �ִ뽺�¹̳� ����
        Player_Atk_Up ���ݷ� ����
        Player_AS_Up ���ݼӵ� ����
        Player_MS_Up �̵��ӵ� ����
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
