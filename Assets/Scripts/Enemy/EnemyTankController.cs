using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : TankController {

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        _rigidBody.mass = _mass;
    }
}
