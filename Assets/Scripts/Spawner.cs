using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy Spawns")]
    [SerializeField] float enemySpawnTime;
    [Header("Enemy Spawns")]
    [SerializeField] float coinSpawnTime;
    void Update()
    {
        SpawnEnemy();
        SpawnCoin();
    }
    void SpawnEnemy()
    {
    }
    void SpawnCoin()
    {
    }
}
