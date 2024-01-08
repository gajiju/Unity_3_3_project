using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Farrange_monster : MonoBehaviour
{
    public GameObject bullet;
    public GameObject monster;
    public bool be_ranger;

    public LayerMask isLayer;
    Rigidbody rigid;
    public int nextMove;
    float nextThinkTime;
     Animator animator;

     Transform player;
    public float speed;
    public Vector2 home;

   // public Transform brain;

    public bool following;


    public float Monster_MaxHp;
    public float Monster_CurrentHp;


    
   // public GameObject exp;
    public Transform tra;


    public float findanything_time = 3;
    public float find_pertime = 3;


        void Start()
    {
        rigid = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //brain = GameObject.FindGameObjectWithTag("brain").transform;
        //  home = transform.position;
        Monster_CurrentHp = Monster_MaxHp;

        nextThinkTime = 3f;

    }
    void FixedUpdate()
    {
        findanything_time -= Time.deltaTime;

        nextMove = Random.Range(-1, 2);
        if (Monster_CurrentHp <= 0) //경험치 생성
        {
         //   Instantiate(exp, tra.position, Quaternion.identity);
            Destroy(gameObject);
        }



       
    Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground", "Player"));

      


        


        if (findanything_time <= 0)
        {
            if (following == false)
            {
                if (rayHit.collider == null)
                {
                    Think();
                    findanything_time = find_pertime;
                }
              
            }
         
        }

    }
    void Think()
   {
      //  rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

   }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (be_ranger == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -Time.deltaTime * speed);
                
            }
            else
            {
                if (be_ranger == false)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
                }
            }
            following = true;
            //  Debug.Log("sss");
           
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



    public void Attack()
    {
        if(be_ranger == true)
        {
            Instantiate(bullet, monster.transform);
        }
        else
        {
            if(be_ranger == false)
            {
                animator.SetTrigger("CloseAttack");
            }
        }
    }


    

  
}

    

   
 
     

     
    
   

