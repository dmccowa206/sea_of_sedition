using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy Spawns")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpawnTime;
    [Header("Coin Spawns")]
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float coinSpawnTime;
    bool eSpawn = true, cSpawn = true;
    float rngPlaceX, rngPlaceY;
    Vector2 spawnLoc, initDest;
    Camera cam;
    Vector2 minBounds, maxBounds;
    GameObject enemyInstance;
    GameManager gameManager;
    void Awake()
    {
        cam = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        gameManager.gameTime += Time.deltaTime;
        if (gameManager.gameTime % enemySpawnTime <= 0.2f && eSpawn)
        {
            eSpawn = false;
            SpawnEnemy();
        }
        else if(gameManager.gameTime % enemySpawnTime >= 0.2f)
        {
            eSpawn = true;
        }
        if (gameManager.gameTime % coinSpawnTime <= 0.2f && cSpawn)
        {
            cSpawn = false;
            SpawnCoin();
        }
        else if(gameManager.gameTime % coinSpawnTime >= 0.2f)
        {
            cSpawn = true;
        }
        
    }
    void SpawnEnemy()//spawns enemy on one of three random edges
    {
        int rngSide = Random.Range(0, 3);
        rngPlaceX = Random.Range(0f,1f);
        switch (rngSide)
        {
            case 0://left
                spawnLoc = cam.ViewportToWorldPoint(new Vector2(-0.05f, rngPlaceX));
                CreateEnemy(spawnLoc);
                break;
            case 1://top
                spawnLoc = cam.ViewportToWorldPoint(new Vector2(rngPlaceX, 1.05f));
                CreateEnemy(spawnLoc);
                break;
            case 2://right
                spawnLoc = cam.ViewportToWorldPoint(new Vector2(1.05f, rngPlaceX));
                CreateEnemy(spawnLoc);
                break;
            default:
                Debug.Log("rngSide switch went wrong");
                break;
        }
    }
    void CreateEnemy(Vector2 spawnPos)
    {
        enemyInstance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemyInstance.GetComponent<EnemyMove>().SetInitDest(RandomInitDest());
    }
    Vector2 RandomInitDest()//decide the init dest for enemy here so I dont
    {//need Camera.main in the move script
        rngPlaceX = Random.Range(0.3f,0.8f);
        rngPlaceY = Random.Range(0.3f,0.8f);
        initDest = cam.ViewportToWorldPoint(new Vector2(rngPlaceX, rngPlaceY));
        return initDest;
    }

    void SpawnCoin()//Spawns a coin at a rnadom place on screen
    {
        rngPlaceX = Random.Range(0.05f, 0.95f);
        rngPlaceY = Random.Range(0.05f, 0.95f);
        spawnLoc = cam.ViewportToWorldPoint(new Vector2(rngPlaceX, rngPlaceY));
        Instantiate(coinPrefab, spawnLoc, Quaternion.identity);
    }
}
