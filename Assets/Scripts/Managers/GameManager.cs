using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    static ResourcesManager _resources = new ResourcesManager();
    public static GameManager Instance {  get { return _instance; } }
    public static ResourcesManager Resource { get { return _resources; } }


    void Init()
    {
        if(_instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            if(go == null)
            {
                go = new GameObject { name = "GameManager" };
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<GameManager>();
        }
    }
}
