using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{
    public LayerMask isLayer;
    Rigidbody2D rigid;
    public int nextMove;
    float nextThinkTime;
     Animator animator;

    public Transform player;
    public float speed;
    public Vector2 home;

    public Transform brain;

    public bool following;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //brain = GameObject.FindGameObjectWithTag("brain").transform;
      //  home = transform.position;
 
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
       // RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.right, 1, LayerMask.GetMask("Player"));
       // RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.left, 1, LayerMask.GetMask("Player"));
        if (rayHit.collider == null)
        {
           // transform.position =  Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
          
            nextThinkTime = Random.Range(2f, 5f);
            Invoke("Think", nextThinkTime);
        }
        //else
       // {
          // if(rayHit.collider == null)
           //{
           // transform.position =  Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
         //  }
            //Debug.Log("player 사라지다");
            //if(rayHit.collider == Player)
            //{
               // transform.position =  Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
          //  }
        //}
    }
    void Think()
   {
      nextMove = Random.Range(-1, 2);
   }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("sss");
following = true;
           if (following == true)
        {
 transform.position =  Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);

        }
    }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            following = false;
        }
    }

  
}

    

   
 
     

     
    
   

