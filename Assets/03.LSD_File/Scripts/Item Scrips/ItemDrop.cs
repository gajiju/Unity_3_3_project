using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemDropSO itemDropSO;
    private SphereCollider Collider;

    private void Awake()
    {
        Collider = GetComponent<SphereCollider>();
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
            Debug.Log("´ê¾Ò´Ù.");
            DropItem();
        }
    }
}
