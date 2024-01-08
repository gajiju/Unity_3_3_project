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
                EndPannel.SetActive(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
