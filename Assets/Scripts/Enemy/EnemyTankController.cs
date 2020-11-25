using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private float _tankSpeed;
    private float _turnSpeed;
    private float _mass;

    [SerializeField]
    private MeshRenderer[] _meshRenderers;

    public void IntializeValues(TankScriptableObject config) {
        _tankSpeed = config.speed;
        _turnSpeed = config.turnSpeed;
        _mass = config.mass;
        
        foreach(MeshRenderer mesh in _meshRenderers) {
            mesh.material.color = config.tankColor;
        }
    } 

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        _rigidBody.mass = _mass;
    }
}
