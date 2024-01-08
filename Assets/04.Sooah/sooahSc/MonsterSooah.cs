using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ���󰡰� �ϱ�
public class MonsterSooah : MonoBehaviour
{
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

    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
        playerStats = player.GetComponent<PlayerStats_Kys>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        SetState();
    }

    void SetState()
    {
        //aIState = state;
        
        if (playerDistance <= monsterSOO.AttackRange)
        {
            //Debug.Log("����");
            attackDelayTime += Time.deltaTime;
            if(attackDelayTime >= 1)
            {
                Attack(monsterSOO.Damage);
                attackDelayTime = 0;
            }
        }
        else if(playerDistance <= monsterSOO.FollowRange)
        {
            //Debug.Log("����");
            Move();
        }
    }
    private void Move()
    {
        // ������ ��ǥ���� �÷��̾� ��ǥ�� ���� ������ ������ ���Ѵ�
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
        // �����Ÿ��ȿ� �÷��̾ ������ �÷��̾�� �������� ������, �ִϸ��̼� on
       

        playerStats.user_date.CurrentStats._CurrentHp -= damage;
        animator.SetTrigger("Attack");
        //Debug.Log(damage + "�������� ���� �÷��̾��ü����" + playerStats.user_date.CurrentStats._CurrentHp);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Player_Weapon_kys weapon = other.GetComponent<Player_Weapon_kys>();
            monsterSOO.maxHP -= weapon.damage;
            Debug.Log("Melee : " + monsterSOO.maxHP);
            StartCoroutine(OnDamage());
            
        }
    }
    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (monsterSOO.maxHP > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.gray;
            Destroy(gameObject, 2);
        }
    }
}
