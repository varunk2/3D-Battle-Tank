using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Joystick joystick;

    private Rigidbody _rigidBody;
    private float _tankSpeed;
    private float _turnSpeed;

    public void Intialize(TankScriptableObject config) {
        _tankSpeed = config.speed;
        _turnSpeed = config.turnSpeed;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();      
    }

    private void Update()
    {
        Movement();
        Turn();
    }
    private void Movement()
    {
        if(joystick.Vertical > 0.2f || joystick.Vertical < -0.2f)
        {
            Vector3 movement = transform.forward * joystick.Vertical * _tankSpeed * Time.deltaTime;

            _rigidBody.MovePosition(_rigidBody.position + movement);
        }
    }
    private void Turn()
    {
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f)
        {
            float turn = joystick.Horizontal * _turnSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0f, turn, 0f);

            _rigidBody.MoveRotation(_rigidBody.rotation * rotation);
        }
    }
}
