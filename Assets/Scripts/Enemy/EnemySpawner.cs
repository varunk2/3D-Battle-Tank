using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int currentSpawnPoint;

    private void Start() {
        currentSpawnPoint = 0;
    }
    void Update()
    {
        SpawnEnemies();    
    }

    private void SpawnEnemies() {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            EnemyTankController enemyTank = TankService.Instance.GetEnemyTank();

            //int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            //enemyTank.gameObject.transform.position = spawnPoints[spawnPointIndex].position;

            enemyTank.gameObject.transform.position = spawnPoints[currentSpawnPoint].position;
            currentSpawnPoint++;
        }
    }
}
