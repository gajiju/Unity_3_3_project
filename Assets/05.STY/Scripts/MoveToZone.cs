using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToZone : MonoBehaviour
{
    public GameObject gameStart;
    public GameObject secondStage;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StartZone"))
        {
            gameObject.transform.position = new Vector3(-95, 0, -35);
            secondStage.SetActive(true);
            Invoke("HidePanel2", 1f);

        }
    }
    private void Start()
    {
        gameStart.SetActive(true);
        Invoke("HidePanel1", 1f);

    }
    void HidePanel1()
    {
        gameStart.SetActive(false);
    }
    void HidePanel2()
    {
        secondStage.SetActive(false);
    }
}
