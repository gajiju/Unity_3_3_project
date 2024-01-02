using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ControllerEvent : MonoBehaviour
{
    public event Action<Vector3> OnMoveEvent;
    
    public void CallMoveEvent(Vector3 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

}
