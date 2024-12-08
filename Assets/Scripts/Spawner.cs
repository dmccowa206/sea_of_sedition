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
    float rngPlaceX, rngPlaceY, timeLeniency = 0.25f;
    Vector2 spawnLoc, initDest;
    Camera cam;
    GameObject enemyInstance;
    GameManager gameManager;
    void Awake()
    {
        cam = Camera.main;
        gameManager = DontDestroyOnLoadManager.GetGameManager();
    }
    void Update()
    {
        gameManager.gameTime += Time.deltaTime;
        if (gameManager.gameTime % enemySpawnTime <= timeLeniency && eSpawn)
        {
            eSpawn = false;
            SpawnEnemy();
        }
        else if(gameManager.gameTime % enemySpawnTime >= timeLeniency)
        {
            eSpawn = true;
        }
        if (gameManager.gameTime % coinSpawnTime <= timeLeniency && cSpawn)
        {
            cSpawn = false;
            SpawnCoin();
        }
        else if(gameManager.gameTime % coinSpawnTime >= timeLeniency)
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
        InitBounds(enemyInstance);
        float size = gameManager.enemySize;
        enemyInstance.transform.localScale = new (size, size, 1);
    }
    Vector2 RandomInitDest()//decide the init dest for enemy here so I dont
    {//need Camera.main in the move script
        rngPlaceX = Random.Range(0.3f,0.8f);
        rngPlaceY = Random.Range(0.3f,0.8f);
        initDest = cam.ViewportToWorldPoint(new Vector2(rngPlaceX, rngPlaceY));
        return initDest;
    }
    void InitBounds(GameObject inst)
    {
        inst.GetComponent<EnemyMove>().SetMinBounds(cam.ViewportToWorldPoint(new Vector2(-0.15f, -0.15f)));
        inst.GetComponent<EnemyMove>().SetMaxBounds(cam.ViewportToWorldPoint(new Vector2(1.15f, 1.15f)));
    }

    void SpawnCoin()//Spawns a coin at a rnadom place on screen
    {
        rngPlaceX = Random.Range(0.05f, 0.95f);
        rngPlaceY = Random.Range(0.05f, 0.95f);
        spawnLoc = cam.ViewportToWorldPoint(new Vector2(rngPlaceX, rngPlaceY));
        Instantiate(coinPrefab, spawnLoc, Quaternion.identity);
    }
}
