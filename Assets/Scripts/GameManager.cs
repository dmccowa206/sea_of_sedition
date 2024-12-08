using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Game Parameters")]
    [SerializeField] float difficultyScalor = 0.03333f;
    [Header("Player Stats")]
    public int hp;
    public int hpMax, gold, wepLvl;
    public float playerSpeed, wepFireRate;
    [Header("Score")]
    public int score;
    public int highScore;
    [Header("Game Time Scaling")]
    public float gameTime;
    public float difficultyLevel;
    public int enemyWepLvl, goldVal;
    public float enemySize, enemySpeed;
    int pirateGold = 0;

    [Header("Prices")]
    public int heal;
    public int hpUp, weapon, speed, sabotage, damage, fireRate;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            gameObject.DontDestroyOnLoad();
            ResetStats();
        }
        else
        {
            Destroy(this);
        }
    }

    public float GetDifficultyLevel()
    {
        return difficultyLevel;
    }
    public float GetScalor()
    {
        return difficultyScalor;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("GameArea");
    }
    public void LoadMenu()
    {
        ResetStats();
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void OnResetButton()
    {
        ResetStats();
        LoadGame();
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void PirateLoot()
    {
        pirateGold ++;
        if (pirateGold >= 10)
        {
            difficultyLevel ++;
            pirateGold = 0;
        }
    }
    void ResetStats()
    {
        //pc stats
        hp = 3;
        hpMax = 3; 
        gold = 0;
        wepLvl = 0;
        wepFireRate = 3f;
        playerSpeed = 4f;
        //score
        score = 0;
        //game time and difficulty
        gameTime = 0f;
        difficultyLevel = 0f;
        goldVal = 1;
        enemyWepLvl = 0;
        enemySize = 1f;
        enemySpeed = 1f;
        //prices
        heal = 5;
        hpUp = 15;
        weapon = 10;
        speed = 10;
        sabotage = 10;
        damage = 10;
        fireRate = 10;  
    }
}
