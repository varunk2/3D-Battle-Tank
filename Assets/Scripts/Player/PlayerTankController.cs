using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : TankController {

    public Joystick joystick;

    private string _fireButton;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        Movement();
        Turn();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire();
        }
    }

    private void Movement() {
        float vertical = joystick.Vertical;
        
        if (vertical > 0.2f || vertical < -0.2f) {
            Vector3 movement = transform.forward * vertical * _tankSpeed * Time.deltaTime;

            _rigidBody.MovePosition(_rigidBody.position + movement);
        }
    }

    private void Turn() {
        float horizontal = joystick.Horizontal;

        if (horizontal > 0.2f || horizontal < -0.2f) {
            float turn = horizontal * _turnSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0f, turn, 0f);

            _rigidBody.MoveRotation(_rigidBody.rotation * rotation);
        }
    }
}
