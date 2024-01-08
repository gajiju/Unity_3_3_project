using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Weapon_kys : MonoBehaviour
{
    public enum Type { Melee };
    public Type type;
    public int damage = 10; //������
    public float AttackSpeed = 0.5f; //���� �ӵ�
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    PlayerStatsHandler_JY user_date;

    public void Awake()
    {
        user_date = GetComponent<PlayerStatsHandler_JY>();
    }


    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
           
        }
    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f); //1������
        //WaitForSeconds() �־��� �ð���ŭ ��ٷ���
        meleeArea.enabled = true;
        trailEffect.enabled = true;
        yield return new WaitForSeconds(0.3f); //1������
        meleeArea.enabled = false;
        yield return new WaitForSeconds(0.3f); //1������
        trailEffect.enabled = false;
    }


}
