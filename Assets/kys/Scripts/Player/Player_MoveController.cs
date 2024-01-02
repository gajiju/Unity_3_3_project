using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_MoveController : Player_ControllerEvent
{
    public void OnMove(InputValue value)
    {
        if (value == null)
            return;
        Vector3 moveInput = value.Get<Vector3>().normalized;
        transform.rotation = Quaternion.LookRotation(moveInput);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveInput), 0.5f * Time.deltaTime);
        CallMoveEvent(moveInput);
    }
}
