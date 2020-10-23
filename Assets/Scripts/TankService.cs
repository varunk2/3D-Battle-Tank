using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public GameObject tankPlayer;
    public Joystick joystick;
    protected override void Awake()
    {
        base.Awake();
        TankService.Instance.GetTank();
    }

    public TankController GetTank()
    {
        Instantiate(tankPlayer, Vector3.zero, Quaternion.identity);
        TankController tankController = tankPlayer.GetComponent<TankController>();
        tankController.joystick = joystick;
        return tankController;
    }

    //public void GetTank()
    //{
    //    Instantiate(tankPlayer);
    //}
}
