using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_Kys : MonoBehaviour
{
    [SerializeField] GameObject _player = null;
    [SerializeField] Vector3 _position = new Vector3(0.0f,6.0f,-5.0f);
    [SerializeField] Vector3 _rotaition = new Vector3(0, 0, 0);

    private void Update()
    {
        transform.rotation = Quaternion.Euler(_rotaition);
        transform.position = _player.transform.position + _position;
        transform.LookAt(_player.transform);
    }
}
