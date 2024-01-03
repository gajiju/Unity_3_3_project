using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerData
{
    public string Player_Name = "ȫ�浿";
    public int Player_CurrentHp; //����ü��
    public int Player_MaxHp; //�ִ� ü��
    public int Player_CurrentSp; //���罺�¹̳�
    public int Player_MaxSp; //�ִ뽺�¹̳�
    public int Player_Atk; //���ݷ�
    public int Player_AS; //���ݼӵ�
    public int Player_MS; //�̵��ӵ�
}

public class PlayerStats_Kys : MonoBehaviour
{


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

        if (Input.GetMouseButtonDown(0))
        {
            State = Player_State.Attack;
            if(State == Player_State.Attack)
            {
                ani.SetBool("Attack", true);
                State = Player_State.Idle;
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
            ani.SetBool("Jump", false);
            IsJump = false;
            
            State = Player_State.Idle;
        }
    }


    public void OnAttack()
    {
        Animator ani = GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsJump == false)
            {
                State = Player_State.Jump;
                ani.SetBool("Jump", true);
                IsJump = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);

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

    public void OnDie()
    {

    }
}
