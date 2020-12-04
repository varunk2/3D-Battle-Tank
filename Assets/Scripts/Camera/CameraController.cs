using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public TankController target;
    [SerializeField] private Vector3 offset;

    private void LateUpdate() {
        if (target != null) {
            float x = target.transform.position.x;
            float z = target.transform.position.z;
            transform.position = new Vector3(x, transform.position.y, z) + offset;
        }
    }
}
