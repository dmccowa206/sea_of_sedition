using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy Spawns")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpawnTime;
    [Header("Coin Spawns")]
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float coinSpawnTime;
    Camera cam = Camera.main;
    Vector2 minBounds, maxBounds;
    void Update()
    {
        SpawnEnemy();
        SpawnCoin();
    }
    void SpawnEnemy()
    {
        int rngSide = Random.Range(0, 3);
        float rngPlace = Random.Range(0,1);
        Vector2 spawnLoc;
        switch (rngSide)
        {
            case 0://left
                spawnLoc = cam.ViewportToWorldPoint(new Vector2(0, rngPlace));
                Instantiate(enemyPrefab, spawnLoc, Quaternion.identity);
                break;
            case 1://top
                spawnLoc = cam.ViewportToWorldPoint(new Vector2(rngPlace, 1));
                Instantiate(enemyPrefab, spawnLoc, Quaternion.identity);
                break;
            case 2://right
                spawnLoc = cam.ViewportToWorldPoint(new Vector2(1, rngPlace));
                Instantiate(enemyPrefab, spawnLoc, Quaternion.identity);
                break;
            default:
                Debug.Log("rngSide switch went wrong");
                break;
        }
    }
    void SpawnCoin()
    {
    }
}
