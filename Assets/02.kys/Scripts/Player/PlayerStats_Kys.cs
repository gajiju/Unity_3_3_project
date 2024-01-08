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
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SocialPlatforms;

/*
public class PlayerData
{
    public string Player_Name = "ȫ�浿";
    public int Player_CurrentHp = 100; //����ü��
    public int Player_MaxHp = 100; //�ִ� ü��
    public int Player_CurrentSp = 100; //���罺�¹̳�
    public int Player_MaxSp = 100; //�ִ뽺�¹̳�
    public int Player_Atk = 10; //���ݷ�
    public int Player_AS = 5; //���ݼӵ�
    public int Player_MS = 5; //�̵��ӵ�
}
*/
public class PlayerStats_Kys : MonoBehaviour
{
    [SerializeField] private EndGame endGame;
    /* public PlayerData userdata = new PlayerData(); */

    #region 플레이어 싱글톤
    static PlayerStats_Kys Player_instance;

    public static PlayerStats_Kys Player_Instance { get { return Player_instance; } }
    #endregion

    public PlayerStatsHandler_JY user_date;
    public Animator ani;

    #region 이동관련
    public InputAction PlayerMove; //�÷��̾� ��Ʈ�ѷ�

    bool iswall = false; //벽충돌 판단여부
    #endregion

    
    float _Radio = 0;
    #region 공격딜레이
    #endregion
    #region 점프
    [SerializeField]float JumpPower = 10.0f;
    private Rigidbody rigid;
    bool IsJump = false;
    #endregion
    #region 공격쿨타임
    float fireDelay;
    bool isAttackReady; 
    public GameObject weapon;

    #endregion
    #region 피격 그림
    Material mat;
    #endregion

    public enum Player_State
    {
        Idle,
        Move,
        Jump,
        UnJump,
        Attack,
        Pain,
        Long_Ranged_Pain,
        Die

    }

    Player_State State = Player_State.Idle;

    public void Awake()
    {
        user_date = GetComponent<PlayerStatsHandler_JY>();
        ani = GetComponent<Animator>();
    }

    public void Start()
    {
        GameManager gmg = GameManager.Instance();
        rigid = GetComponent<Rigidbody>();
        mat = gameObject.GetComponent<MeshRenderer>().material;

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
        
        if (user_date.CurrentStats._CurrentHp == 0)
        {
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
            case Player_State.Long_Ranged_Pain:
                OnLong_Ranged_Pain();
                break;
        }
    }
    private void FixedUpdate()
    {
        if (user_date.CurrentStats._CurrentHp <= 0)
        {
            OnDie();
        }
        StopWall();
    }

    private void OnDestroy()
    {
        GameManager.Input.KeyAction -= OnMove;
        
        GameManager.Input.KeyAction -= OnJump;
        
        GameManager.Input.KeyAction -= OnAttack;
        
        GameManager.Input.KeyAction -= OnWhirlwind;
        
        GameManager.Input.KeyAction -= OnSplint;
    }

    #region 대기중
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
        //Animator ani = GetComponent<Animator>();
        if (State == Player_State.Die)
            return;
        State = Player_State.Move;
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);
            if(iswall)
            {
                transform.position += Vector3.left * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * user_date.CurrentStats._MS;
                
            }
            _Radio = Mathf.Lerp(_Radio, 1, 10.0f * Time.deltaTime);
            ani.SetFloat("Idle_Run_Radio", _Radio);
        }
        else if (Input.GetKey(KeyCode.D))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);
            if (iswall)
            {
                transform.position += Vector3.right * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * user_date.CurrentStats._MS;
            }
            _Radio = Mathf.Lerp(_Radio, 1, 10.0f * Time.deltaTime);
            ani.SetFloat("Idle_Run_Radio", _Radio);
        }
        else
        {
            State = Player_State.Idle;
        }

    }

    void StopWall() //벽 충돌
    {
        
        //Debug.DrawRay(transform.position, transform.forward, Color.green); 
        iswall = Physics.Raycast(transform.position, transform.forward,1, LayerMask.GetMask("Wall")) ;
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
            ani.SetBool("Jump", false);
            IsJump = false;

            State = Player_State.Idle;
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            if (State == Player_State.Attack)
            {

            }
            else if ((State == Player_State.Idle || State == Player_State.Move)) //피격
            {
                State = Player_State.Pain;
            }
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            if (State == Player_State.Attack)
            {

            }
            else if ((State == Player_State.Idle || State == Player_State.Move)) //피격
            {
                State = Player_State.Long_Ranged_Pain;
            }
        }
    }


    #region 공격
    public void OnAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Player_Weapon_kys eqweapon = weapon.GetComponent<Player_Weapon_kys>();
            /* 공격 쿨타임
            fireDelay = Time.deltaTime;
            isAttackReady = eqweapon.AttackSpeed < fireDelay;
            */
            Animator ani = GetComponent<Animator>();
            State = Player_State.Attack;

            if (State == Player_State.Attack)
            {
                eqweapon.Use();
                ani.SetTrigger("Attack");
                fireDelay = 0;
            }
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

    #region 피격
    public void OnPain()
    {
        Monster_Kys monster = new Monster_Kys();

        Animator ani = GetComponent<Animator>();
        if (State == Player_State.Die)
            return;
        else if(State == Player_State.Pain)
        {
            Debug.Log("아야");
            ani.SetTrigger("Pain");
            
            if(user_date.CurrentStats._CurrentHp > 0)
            {
                user_date.CurrentStats._CurrentHp -= monster.Monster_Attack; //근거리 피격
                StartCoroutine(OnPainOn());
                Debug.Log($" 피격: {monster.Monster_Attack} 현재체력: {user_date.CurrentStats._CurrentHp}");
                State = Player_State.Idle;
            }
            if(user_date.CurrentStats._CurrentHp <= 0)
            {
            OnDie();
            }
        }
    }

    public void OnLong_Ranged_Pain()
    {
        MonsterAttack monster = new MonsterAttack();

        Animator ani = GetComponent<Animator>();
        if (State == Player_State.Die)
            return;
        else if (State == Player_State.Pain)
        {
            Debug.Log("아야");
            ani.SetTrigger("Pain");

            if (user_date.CurrentStats._CurrentHp > 0)
            {
                user_date.CurrentStats._CurrentHp -= monster.damage; //원거리 피격
                StartCoroutine(OnPainOn());
                Debug.Log($" 피격: {monster.damage} 현재체력: {user_date.CurrentStats._CurrentHp}");
                State = Player_State.Idle;
            }
            if (user_date.CurrentStats._CurrentHp <= 0)
            {
                OnDie();
            }
        }
    }

    IEnumerator OnPainOn()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.5f);

        if (user_date.CurrentStats._CurrentHp > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.gray;
        }
    }
    #endregion

    #region 스킬
    public void OnWhirlwind()
    {
        Player_Weapon_kys eqweapon = weapon.GetComponent<Player_Weapon_kys>();
        Animator ani = GetComponent<Animator>();
        if (Input.GetMouseButton(1))
        {
            if (State == Player_State.Die)
                return;
            if (user_date.CurrentStats._CurrentSp >= 20f)
            {
                if (State == Player_State.Idle || State == Player_State.Attack || State == Player_State.Jump||State == Player_State.Move)
                {
                    eqweapon.Use();
                    ani.SetBool("Whirlwind", true);
                }
            }
            else
            {
                ani.SetBool("Whirlwind", false);
                State = Player_State.Idle;
            }
        }
        else
        {
            ani.SetBool("Whirlwind", false);
            State = Player_State.Idle;
        }
    }

    public void OnSplint()
    {
        Animator ani = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (State == Player_State.Die)
                return;
            if (user_date.CurrentStats._CurrentSp >= 10f)
            {
                if (State == Player_State.Idle || State == Player_State.Attack || State == Player_State.Jump ||State == Player_State.Move)
                {
                user_date.CurrentStats._MS = 15f; 
                ani.SetBool("Splint", true);
                }
            }
            else
            {
                user_date.CurrentStats._MS = 10f;
                ani.SetBool("Splint", false);
                State = Player_State.Idle;
            }

        }
        else
        {
            user_date.CurrentStats._MS = 10f;
            ani.SetBool("Splint", false);
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
        endGame.GameOver = true;
    }

    
    #endregion
}