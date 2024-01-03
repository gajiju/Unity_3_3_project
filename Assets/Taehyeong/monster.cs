using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{
    public LayerMask isLayer;
    Rigidbody rigid;
    public int nextMove;
    float nextThinkTime;
     Animator animator;

     Transform player;
    public float speed;
    public Vector2 home;

    public Transform brain;

    public bool following;


    public float Monster_MaxHp;
    public float Monster_CurrentHp;


    
    public GameObject exp;
    public Transform tra;
   
      



        void Start()
    {
        rigid = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //brain = GameObject.FindGameObjectWithTag("brain").transform;
        //  home = transform.position;
        Monster_CurrentHp = Monster_MaxHp;
 
    }
    void FixedUpdate()
    {
        if (Monster_CurrentHp <= 0) //경험치 생성
        {
            Instantiate(exp, tra.position, Quaternion.identity);
            Destroy(gameObject);
        }



        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground", "Player"));

      


        if (following == false)
        {
            if (rayHit.collider == null)
            {
           nextThinkTime = Random.Range(2f, 5f);
                Invoke("Think", nextThinkTime);
            }
            else
            {

            }
        }       
    }
    void Think()
   {
      nextMove = Random.Range(-1, 2);
   }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            following = true;
          //  Debug.Log("sss");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
            Invoke("Attack", nextThinkTime);

         
            if (following == true)
            {


            }
        }
    }
  

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            following = false;
            Debug.Log("벗어남");
        }
    }






    

  
}

    

   
 
     

     
    
   

