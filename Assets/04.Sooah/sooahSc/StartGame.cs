using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject startBtn;
    private bool onButton;
    public bool OnButton 
    { 
        get { return onButton; }
        set 
        { 
            if(value)
            {
                onButton = value;
                startBtn.SetActive(true);
            }
        }   
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startBtn.SetActive(true);
        }
    }

    //public void OnMenu(bool value)
    //{
    //    startBtn.SetActive(value);
    //}

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
