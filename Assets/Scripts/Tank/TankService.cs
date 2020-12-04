using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public Joystick joystick;

    [SerializeField] private TankScriptableObjectList tankList;
    [SerializeField] private PlayerTankController playerTank;
    [SerializeField] private EnemyTankController enemyTank;

    protected override void Awake()
    {
        base.Awake();
        TankService.Instance.GetPlayerTank();
    }

    public PlayerTankController GetPlayerTank() {
        PlayerTankController playerTankController = Instantiate<PlayerTankController>(playerTank, Vector3.zero, Quaternion.identity);
        playerTankController.joystick = joystick;
        playerTankController.Initialize(tankList.tanks[0]);
        
        return playerTankController;
    }

    public EnemyTankController GetEnemyTank() {
        EnemyTankController enemyTankController = Instantiate<EnemyTankController>(enemyTank, Vector3.zero, Quaternion.identity);
        enemyTankController.Initialize(tankList.tanks[1]);

        return enemyTankController;
    }
}
