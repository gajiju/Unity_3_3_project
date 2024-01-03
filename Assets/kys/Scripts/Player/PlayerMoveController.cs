using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _Radio = 0;
    

    private void Start()
    {
        GameManager gmg = GameManager.Instance();



        GameManager.Input.KeyAction -= OnKeyBord;
        GameManager.Input.KeyAction += OnKeyBord;
    }

    private void Update()
    {

    }



    void OnKeyBord()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
            
        }
        else
        {
        }



    }
    

}
