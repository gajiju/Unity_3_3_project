using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    ResourcesManager _resources = new ResourcesManager();
    InputManager _input = new InputManager();

    public static GameManager Instance() { Init();  return _instance;}
    public static ResourcesManager Resource { get { return _instance._resources; } }

    public static InputManager Input { get { return _instance._input; } }

    public Image Hpbar;
    public Image Spbar;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
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
