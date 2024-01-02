using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerStats_Kys : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;
    float _Radio = 0;
    
    [SerializeField]float JumpPower = 5.0f;
    private Rigidbody rigid;
    bool IsJump = false;

    public enum Player_State
    {
        Idle,
        Move,
        Jump,
        UnJump,
        Attack,
        Die
    }

    Player_State State = Player_State.Idle;

    public void Start()
    {
        GameManager gmg = GameManager.Instance();

        GameManager.Input.KeyAction -= OnMove;
        GameManager.Input.KeyAction += OnMove;
    }

    public void Update()
    {
        
        switch (State)
        {
            case Player_State.Idle:
                OnIdle();
                break;
            case Player_State.Move:
                OnMove();
                break;
            case Player_State.Jump:
                OnJump();
                break;
            case Player_State.Attack:
                OnAttack();
                break;

        }
    }

    public void OnIdle()
    {
        _Radio = Mathf.Lerp(_Radio, 0, 5.0f * Time.deltaTime);
        Animator ani = GetComponent<Animator>();
        ani.SetFloat("Idle_Run_Radio", _Radio);
        ani.Play("Idle_Run");
    }
    public void OnMove()
    {
        if (State == Player_State.Die)
            return;

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
        _Radio = Mathf.Lerp(_Radio, 1, 10.0f * Time.deltaTime);
        Animator ani = GetComponent<Animator>();
        ani.SetFloat("Idle_Run_Radio", _Radio);
        ani.Play("Idle_Run");

    }
    public void OnJump()
    {
        
        if(Input.GetKey(KeyCode.Space))
        {
            State = Player_State.Jump;

            if(IsJump == false &&State == Player_State.Jump)
            {
                IsJump = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJump = false;
        }
    }

    public void OnAttack()
    {
        
    }
    public void OnDie()
    {

    }
}
