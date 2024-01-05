using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToZone : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StartZone"))
        {
            gameObject.transform.position = new Vector3(-95, 0, -35);
        }
    }
}
