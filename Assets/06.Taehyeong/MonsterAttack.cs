using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
  //  public Transform pos;
   // public Vector2 BoxSixe;
  public Transform player;
    public bool degree;
  //  public int Hpreducep;

    public float speed;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, -0, 0);


        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.x - player.transform.position.x < 0)
        {

            degree = true;



        }
        else if (transform.position.x - player.transform.position.x > 0)
        {

            degree = false;
           
        }
    }


    void Update()
    {
       
        if (degree == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        else
        {
            if(degree == false)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }


        




    }

   private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
          //  collider.transform.GetComponent<Player>().Hp(Hpreducep);
            Debug.Log("player attack");
            Destroy(gameObject);
        }
    }

   

   
}
