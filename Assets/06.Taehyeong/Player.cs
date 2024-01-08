using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float PlayerCurrentHp;
    public float PlayerMaxHp;
    public float Exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Hp(int Hpreducep)
    {
        PlayerCurrentHp = PlayerCurrentHp - Hpreducep;
    }
    public void getexp(int exppoint)
    {
        Exp = Exp + exppoint;
    }
}
