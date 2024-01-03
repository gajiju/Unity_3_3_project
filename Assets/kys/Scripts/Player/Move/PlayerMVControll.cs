using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMVControll : MonoBehaviour
{
    public event Action<Vector3> OnMoveEvent;
    public event Action<Vector3> OnJump;
    public event Action<Vector3> OnAttack;


    public void CallMoveEvent(Vector3 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallAttackEvent(Vector3 direction)
    {
        OnAttack?.Invoke(direction);
    }
}
