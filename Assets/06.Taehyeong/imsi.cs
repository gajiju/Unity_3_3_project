using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imsi : MonoBehaviour
{
    public Transform player;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - player.transform.position.x > 0)
        {
            transform.position -= new Vector3(-speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, -90, 0);

          
        }
        else if (transform.position.x - player.transform.position.x < 0)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            return;
        }
    }
}
