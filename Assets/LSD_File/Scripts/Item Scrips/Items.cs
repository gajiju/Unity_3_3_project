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
    private void ItemPickUp()
    {
        // ĳ���Ϳ��� �ش� ������ �ɷ� �ڵ� �ۼ�
    }
    private void OnTriggerEnter(Collider collision)
    {
        // �̺�Ʈ Player �±� �浹 ����
        if (collision.gameObject.tag == "Player")
        {
            ItemPickUp();
        }
    }
}
