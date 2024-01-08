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
    public string Player_Name = "ȫ�浿";
    public int Player_CurrentHp = 50; //����ü��
    public int Player_MaxHp = 100; //�ִ� ü��
    public int Player_CurrentSp = 50; //���罺�¹̳�
    public int Player_MaxSp = 100; //�ִ뽺�¹̳�
    public int Player_Atk = 10; //���ݷ�
    public int Player_AS = 5; //���ݼӵ�
    public int Player_MS = 5; //�̵��ӵ�
}

public class PlayerStats_Kys : MonoBehaviour
{

    public PlayerData userdata = new PlayerData();

    #region �÷��̾� �̵�����
    public InputAction PlayerMove; //�÷��̾� ��Ʈ�ѷ�
    [SerializeField] float _speed = 10.0f; //�̵��ӵ�

    #endregion

    
    float _Radio = 0;

    #region ���� ����
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
        Whirlwind,
        Splint,
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
        GameManager.Input.KeyAction -= OnWhirlwind;
        GameManager.Input.KeyAction += OnWhirlwind;
        GameManager.Input.KeyAction -= OnSplint;
        GameManager.Input.KeyAction += OnSplint;
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
            case Player_State.Whirlwind:
                OnWhirlwind();
                break;
            case Player_State.Splint:
                OnSplint();
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

    #region ���
    public void OnIdle()
    {
        if (State == Player_State.Die)
            return;


        _Radio = Mathf.Lerp(_Radio, 0, 10.0f * Time.deltaTime);
        Animator ani = GetComponent<Animator>();
        ani.SetFloat("Idle_Run_Radio", _Radio);
    }
    #endregion
    #region �̵�
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
    #region ����
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
            ani.SetBool("Jump", false);
            IsJump = false;

            State = Player_State.Idle;
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            if (State == Player_State.Attack)
            {
                MonsterAttack monster = GetComponent<MonsterAttack>();


            }
            else if ((State == Player_State.Idle || State == Player_State.Move)) //�ǰ�
            {
                State = Player_State.Pain;
            }
        }
    }



    #region ����
    public void OnAttack()
    {
        Animator ani = GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
                ani.SetTrigger("Attack");
        }
    }
    public void OnAttackOnOff()
    {
        if(State == Player_State.Idle || State == Player_State.Move || State == Player_State.Jump)
        {
            State = Player_State.Attack;
        }
        else if(State == Player_State.Attack)
        {
            State = Player_State.Idle;
        }
    }


    /*
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
    */

    #endregion

    #region �ǰ�
    public void OnPain()
    {
        Animator ani = GetComponent<Animator>();
        if (State == Player_State.Die)
            return;
        else if(State == Player_State.Pain)
        {
            Debug.Log("�ƾ�");
            ani.SetTrigger("Pain");

            /*
            if(userdata.Player_CurrentHp > 0)
            {
            userdata.Player_CurrentHp -= Monster_kys.Damage;
             State = Player_State.Idle;
            }
            if(userdata.Player_CurrentHp <= 0)
            {
            userdata.Player_CurrentHp = 0;
            State = Player_State.Die;
            }
            */
        }
    }
    #endregion

    public void OnSplint()
    {
        Animator ani = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (State == Player_State.Die)
                return;
            if (State == Player_State.Idle || State == Player_State.Attack || State == Player_State.Jump ||State == Player_State.Move)
            {
                _speed = 15f; 
                ani.SetBool("Splint", true);
            }
        }
        else
        {
            _speed = 10f;
            ani.SetBool("Splint", false);
            State = Player_State.Idle;
        }
    }



    #region ����
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
