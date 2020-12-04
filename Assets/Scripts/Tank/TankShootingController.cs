using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShootingController : MonoBehaviour
{
    public Rigidbody shell;
    public Transform fireTransform;
    public float minLaunchForce = 15f;
    public float maxLaunchForce = 30f;
    public float maxchargeTime = 0.75f;

    private string fireButton;
    private float _currentLaunchForce;
    private float _chargeSpeed;
    private bool _fired;

    private void Awake() {

        _currentLaunchForce = minLaunchForce;

    }
    void Start()
    {
        fireButton = "Fire1";
        _chargeSpeed = (maxLaunchForce - minLaunchForce) / maxchargeTime;
    }

    void Update()
    {

        if (_currentLaunchForce >= maxLaunchForce && !_fired) {

            _currentLaunchForce = maxLaunchForce;
            Fire();

        } else if (Input.GetButtonDown(fireButton)) {
            
            _fired = false;
            _currentLaunchForce = minLaunchForce;
        
        } else if (Input.GetButton(fireButton) && !_fired) {
        
            _currentLaunchForce += _chargeSpeed * Time.deltaTime;
        
        } else if (Input.GetButtonUp(fireButton) && !_fired) {
            
            Fire();
        
        }
    }

    private void Fire() {
        _fired = true;

        //Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        ShellController shellInstance = ShellManager.Instance.GetShell();

        //shellInstance.velocity = _currentLaunchForce * fireTransform.forward;

        _currentLaunchForce = minLaunchForce;
    }
}
