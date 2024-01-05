using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_GiveExp : MonoBehaviour
{
    public Transform pos;
    public Vector2 BoxSixe;
    public int exppoint;
 
    void Start()
    {
        transform.SetParent(null); //경험치가 파괴됨을 방지
    }


    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, BoxSixe, 0); //플레이어 감지 콜라이더
        foreach (Collider2D collider in collider2Ds)
            if (collider.tag == "Player")
            {
                collider.GetComponent<Player>().getexp(exppoint); //플레이어가 닿으면 플레이어 코드의 경험치를 올려줌
                Destroy(gameObject);
            }
    }

}
