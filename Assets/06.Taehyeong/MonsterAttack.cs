using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject bullet;
  //  public Transform pos;
   // public Vector2 BoxSixe;
  public Transform player;
    public bool degree;
    //  public int Hpreducep;
    public float b_damage = 1;
    public float speed;
    public float damage = 5;

    private void Start()
    {

        //transform.SetParent(null);
        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.position += new Vector3(0, 2, 0);

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
    
   private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
          collider.transform.GetComponent<PlayerStats_Kys>().Bulletdamaged(b_damage);
            Destroy(gameObject);
            Debug.Log("player attack");
           
        }
    }

   

   
}
