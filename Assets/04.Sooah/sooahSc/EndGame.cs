using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject EndPannel;
    private bool gameOver;
    public bool GameOver
    {
        get { return gameOver; }
        set
        {
            if (value)
            {
                gameOver = value;
                //Time.timeScale = 0.0f;
                EndPannel.SetActive(true);
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndZone"))
        {
            EndPannel.SetActive(true);

        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
        //Time.timeScale = 1.0f;
    }
}
