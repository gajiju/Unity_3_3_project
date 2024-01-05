using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;

    private Collider itemCollider;

    private void Awake()
    {
        itemCollider = GetComponent<Collider>();

        if (gameObject != null)
        {
            Invoke("ActiveItemCollider", 1f);
        }
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
                Destroy(gameObject);
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
                Debug.Log("���� ü�� ����");
                break;
            case "Player_CurrentSp_Up":
                Debug.Log("���� ���¹̳� ����");
                break;
            case "Player_Atk_Up":
                Debug.Log("���ݷ� ����");
                break;
            case "Player_AS_Up":
                Debug.Log("���ݼӵ� ����");
                break;
            case "Player_MS_Up":
                Debug.Log("�̵��ӵ� ����");
                break;
        }
    }
}
