using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 따라가게 하기
public class MonsterSooah : MonoBehaviour
{
    private float MonsterMove = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private MonsterSOO monsterSOO;
    private Animator animator;
    private float playerDistance;
    private float attackDelayTime;
    //private AIState aIState;
    
    private PlayerStats_Kys playerStats;

    //public enum AIState
    //{
    //    Move,
    //    Attack,
    //}
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
        playerStats = player.GetComponent<PlayerStats_Kys>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        SetState();
    }

    void SetState()
    {
        //aIState = state;
        
        if (playerDistance <= monsterSOO.AttackRange)
        {
            Debug.Log("어택");
            attackDelayTime += Time.deltaTime;
            if(attackDelayTime >= 1)
            {
                Attack(monsterSOO.Damage);
                attackDelayTime = 0;
            }
        }
        else if(playerDistance <= monsterSOO.FollowRange)
        {
            Debug.Log("무브");
            Move();
        }
    }
    private void Move()
    {
        // 몬스터의 좌표에서 플레이어 좌표를 빼서 몬스터의 방향을 구한다
        animator.SetBool("Move", true);
        if (transform.position.x - player.transform.position.x > 0)
        {
            transform.position += new Vector3(-(monsterSOO.speed) * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, -90, 0);

            //transform.position += new Vector3(-1, 0, 0) * monsterSOO.speed * Time.deltaTime;
        }
        else if (transform.position.x - player.transform.position.x < 0)
        {
            transform.position += new Vector3(monsterSOO.speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            return;
        }

    }

    private void Attack(int damage)
    {
        // 사정거리안에 플레이어가 들어오면 플레이어에게 데미지를 입힌다, 애니메이션 on
        
        playerStats.user_date.CurrentStats._CurrentHp -= damage;
        animator.SetTrigger("Attack");
        Debug.Log(damage + "데미지가 들어갔다 플레이어남은체력은" + playerStats.user_date.CurrentStats._CurrentHp);
    }
}
