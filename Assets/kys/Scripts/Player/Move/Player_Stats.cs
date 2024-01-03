using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    private PlayerMVControll _controller;
    private Vector3 _movementDirectiopn = Vector3.zero;
    private Rigidbody _rigid;

    public void Awake()
    {
        _controller = GetComponent<PlayerMVControll>();
        _rigid = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirectiopn);
    }
    private void Move(Vector3 direction)
    {
        _movementDirectiopn = direction;
    }
    private void ApplyMovement(Vector3 direction)
    {
        direction = direction * 5;
        _rigid.velocity = direction;
    }
}
