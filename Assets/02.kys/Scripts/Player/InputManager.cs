using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{

    /*
    public event Action<Vector3> OnMoveEvent;

    public void CallMoveEvent(Vector3 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    */
    public Action KeyAction = null;
    
    
    public void OnUpdate()
    {
        if(Input.anyKey == false)
        {
            return;
        }
        if(KeyAction != null)
        {
            KeyAction.Invoke();
        }

    }
    
}
