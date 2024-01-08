using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
  //  public Transform pos;
   // public Vector2 BoxSixe;
  //  public Transform player;
   
  //  public int Hpreducep;

    public float speed;

    private void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);


        



    }

  //  private void OnTriggerEnter(Collider collider)
   // {
     //   if (collider.transform.tag == "Player")
      //  {
       //     collider.transform.GetComponent<Player>().Hp(Hpreducep);
       //     Debug.Log("player attack");
      //      Destroy(gameObject);
      //  }
  //  }

   

   
}
