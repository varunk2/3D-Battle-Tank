using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public Joystick joystick;

    [SerializeField] private TankScriptableObjectList tankList;
    [SerializeField] private Tank playerTank;
    //[SerializeField] private TankController playerTank;

    [SerializeField]
    private EnemyTankController enemyTank;

    protected override void Awake()
    {
        base.Awake();
        TankService.Instance.GetTank();
    }

    //public TankController GetTank()
    public Tank GetTank() {
        //TankController tankController = Instantiate<TankController>(playerTank, Vector3.zero, Quaternion.identity);
        Tank tankController = Instantiate<Tank>(playerTank, Vector3.zero, Quaternion.identity);
        tankController.joystick = joystick;
        tankController.Intialize(tankList.tanks[0]);
        
        return tankController;
    }

    public EnemyTankController GetEnemyTank() {
        EnemyTankController enemyTankController = Instantiate<EnemyTankController>(enemyTank, Vector3.zero, Quaternion.identity);
        enemyTankController.IntializeValues(tankList.tanks[1]);

        return enemyTankController;
    }
}
