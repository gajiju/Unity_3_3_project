using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Weapon_kys : MonoBehaviour
{
    public enum Type { Melee };
    public Type type;
    public int damage = 10; //데미지
    public float AttackSpeed = 0.5f; //공격 속도
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
        yield return new WaitForSeconds(0.1f); //1프레임
        //WaitForSeconds() 주어진 시간만큼 기다려라
        meleeArea.enabled = true;
        trailEffect.enabled = true;
        yield return new WaitForSeconds(0.3f); //1프레임
        meleeArea.enabled = false;
        yield return new WaitForSeconds(0.3f); //1프레임
        trailEffect.enabled = false;
    }


}
