using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMVControll : PlayerMVControll
{
    public Camera _camera;

    public void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector3 moveInput = value.Get<Vector3>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnJump(InputValue value)
    {

    }
    public void OnAttack(InputValue value)
    {
        
    }
}
