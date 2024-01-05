using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemDropSO itemDropSO;
    private Collider Collider;

    private void Awake()
    {
        Collider = GetComponent<Collider>();
        Invoke("ActiveItemCollider", 1f);
    }
    private void ActiveItemCollider()
    {
        if (Collider != null)
        {
            Collider.enabled = true;
        }
    }
    public void DropItem()
    {
        itemDropSO.ItemDrop(transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!collision.isTrigger)
            {
                Debug.Log("아이템 박스를 열었다.");
                DropItem();
            }
        }
    }
}
