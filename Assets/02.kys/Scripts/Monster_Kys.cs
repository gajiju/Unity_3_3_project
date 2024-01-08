using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Kys : MonoBehaviour
{
    public int Monster_maxHp = 100;
    public int Monster_curHp = 100;
    public int Monster_Attack = 10;

    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;

    private void Update()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Player_Weapon_kys weapon = other.GetComponent<Player_Weapon_kys>();
            Monster_curHp -= weapon.damage;
            Debug.Log("Melee : " + Monster_curHp);
            StartCoroutine(OnDamage());

        }
    }

    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if(Monster_curHp > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.gray;
            Destroy(gameObject, 4);
        }
    }

}
