using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public LayerMask isLayer;
    public int nextMove;
    float nextThinkTime;
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground", "Player"));

        if (rayHit.collider == null)
        {
            nextThinkTime = Random.Range(5f, 10f);
            Invoke("Think", nextThinkTime);
        }
    }

    void Think()
    {
        nextMove = Random.Range(-5, 7);
    }
}
