using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
//using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.ProBuilder.MeshOperations;

[Serializable]
public class PlayerData
{
    public string Player_Name = "홍길동";
    public int Player_CurrentHp = 100; //현재체력
    public int Player_MaxHp = 100; //최대 체력
    public int Player_CurrentSp = 100; //현재스태미나
    public int Player_MaxSp = 100; //최대스태미나
    public int Player_Atk = 10; //공격력
    public int Player_AS = 5; //공격속도
    public int Player_MS = 5; //이동속도
}

public class PlayerStats_Kys : MonoBehaviour
{

    public PlayerData userdata = new PlayerData();

    #region 플레이어 이동관련
    public InputAction PlayerMove; //플레이어 컨트롤러
    [SerializeField] float _speed = 10.0f; //이동속도

    #endregion

    
    float _Radio = 0;

    #region 점프 구현
    [SerializeField]float JumpPower = 10.0f;
    private Rigidbody rigid;
    bool IsJump = false;
    #endregion



    public enum Player_State
    {
        Idle,
        Move,
        Jump,
        UnJump,
        Attack,
        Pain,
        Die

    }

    Player_State State = Player_State.Idle;



    public void Start()
    {
        GameManager gmg = GameManager.Instance();
        rigid = GetComponent<Rigidbody>();

        GameManager.Input.KeyAction -= OnMove;
        GameManager.Input.KeyAction += OnMove;
        GameManager.Input.KeyAction -= OnJump;
        GameManager.Input.KeyAction += OnJump;
        GameManager.Input.KeyAction -= OnAttack;
        GameManager.Input.KeyAction += OnAttack;
        
    }

    public void Update()
    {
        if(userdata.Player_CurrentHp == 0)
        {
            State = Player_State.Die;
            OnDie();
        }

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
            case Player_State.Pain:
                OnPain();
                break;


        }
    }
    private void FixedUpdate()
    {
        if (userdata.Player_CurrentHp == 0)
            return;
    }

    #region 대기
    public void OnIdle()
    {
        if (State == Player_State.Die)
            return;


        _Radio = Mathf.Lerp(_Radio, 0, 10.0f * Time.deltaTime);
        Animator ani = GetComponent<Animator>();
        ani.SetFloat("Idle_Run_Radio", _Radio);
    }
    #endregion
    #region 이동
    public void OnMove()
    {
        Animator ani = GetComponent<Animator>();
        if (State == Player_State.Die)
            return;
        State = Player_State.Move;
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
            _Radio = Mathf.Lerp(_Radio, 1, 10.0f * Time.deltaTime);
            ani.SetFloat("Idle_Run_Radio", _Radio);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
            _Radio = Mathf.Lerp(_Radio, 1, 10.0f * Time.deltaTime);
            ani.SetFloat("Idle_Run_Radio", _Radio);

        }
        else
        {
            State = Player_State.Idle;
        }

    }
    #endregion
    #region 점프
    public void OnJump()
    {
        Animator ani = GetComponent<Animator>();

        if (Input.GetKey(KeyCode.Space) && (State == Player_State.Idle || State == Player_State.Move) )
        {
            State = Player_State.Jump;
            if (IsJump == false)
            {
                IsJump = true;
                ani.SetBool("Jump", true);
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }

    }
    #endregion
    private void OnCollisionEnter(Collision collision)
    {
        Animator ani = GetComponent<Animator>();
        if (collision.gameObject.CompareTag("Ground"))
        {
            ani.SetTrigger("JumpEnd");
            ani.SetBool("Jump",false);
            IsJump = false;
            
            State = Player_State.Idle;
        }
        else if (collision.gameObject.CompareTag("Monster") && (State == Player_State.Idle || State == Player_State.Move)) //피격
        {
            State = Player_State.Pain;
        }

        else if (collision.gameObject.CompareTag("Monster") && State == Player_State.Attack) // 공격
        {
            Debug.Log("공격");
            OnHitEvent();
        }


    }


    #region 공격
    public void OnAttack()
    {
        Animator ani = GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
            State = Player_State.Attack;
            if (State == Player_State.Attack)
            {
                ani.SetTrigger("Attack");
                State = Player_State.Idle;
            }
            else
            {
                return;
            }

        }
    }
    public void OnHitEvent()
    {
        
        State = Player_State.Idle;
    }
    #endregion

    #region 피격
    public void OnPain()
    {
        if (State == Player_State.Die)
            return;
        if(State == Player_State.Pain)
        {
            Debug.Log("아야");
            //userdata.Player_CurrentHp -= Monster_kys.Damage;
            State = Player_State.Idle;
        }
    }
    #endregion

    #region 죽음
    public void OnDie()
    {
        Animator ani = GetComponent<Animator>();
        State = Player_State.Die;
        ani.SetTrigger("Die");
       // yield return new WaitForSeconds(0.5f);
        ani.SetTrigger("DieGround");
    }
    #endregion
}
