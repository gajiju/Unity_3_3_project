using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToZone : MonoBehaviour
{
    public GameObject startGame;
    public GameObject stage;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StartZone"))
        {
            gameObject.transform.position = new Vector3(-95, 0, -35);
            stage.SetActive(true);
            Invoke("HidePanel", 1f);

        }
    }
    private void Start()
    {
        startGame.SetActive(true);
        Invoke("HidePanel", 1f);
    }
    void HidePanel()
    {
        stage.SetActive(false);
        startGame.SetActive(false);
    }
}
