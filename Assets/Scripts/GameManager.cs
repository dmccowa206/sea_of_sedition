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
    public float gameTime, difficultyLevel;
    public int score, highScore, hp, gold, wepLvl, hpMax;
    public float wepFireRate, playerSpeed;
    int pirateGold = 0;

    [Header("Prices")]
    public int heal = 5;
    public int hpUp = 15;
    public int weapon = 10;
    public int speed = 10;
    public int sabotage = 10;
    public int damage = 10;
    public int fireRate = 10;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            gameObject.DontDestroyOnLoad();
            score = 0;
            highScore = 0;
            hp = 3;
            hpMax = 3;
            gold = 0;
            wepLvl = 0;
            wepFireRate = 5f;
            playerSpeed = 5f;
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
        score = 0;
        hp = 3;
        gold = 0;
        hpMax = 3;  
        wepLvl = 0;
        wepFireRate = 5f;
        playerSpeed = 5f;
        gameTime = 0f;
        difficultyLevel = 0f;
        heal = 5;
        hpUp = 15;
        weapon = 10;
        speed = 10;
        sabotage = 10;
        damage = 10;
        fireRate = 10;  
    }
}
