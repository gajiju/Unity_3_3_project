using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool IsPause;
    public GameObject pauseImage;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) 
        { 
            if(IsPause==false) 
            {
                Time.timeScale = 0f;
                IsPause = true;
                pauseImage.SetActive(true);

                return;

            }

            if(IsPause == true)
            {
                Time.timeScale = 1f;
                IsPause = false;
                return;
            }


        }
    }

}
