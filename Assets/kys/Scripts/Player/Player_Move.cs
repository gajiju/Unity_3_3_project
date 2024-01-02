using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Player_ControllerEvent _controller;
    private Vector3 _movementDirection = Vector3.zero;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<Player_ControllerEvent>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector3 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector3 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
    }
}

