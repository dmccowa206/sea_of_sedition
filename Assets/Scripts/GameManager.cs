using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Parameters")]
    [SerializeField] float difficultyScalor = 0.03333f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI goldText;
    public float gameTime, difficultyLevel;
    public int score = 0, highScore = 0, hp = 3, gold = 0, wepLvl = 0, hpMax = 3;

    public float GetDifficultyLevel()
    {
        return difficultyLevel;
    }
    public float GetScalor()
    {
        return difficultyScalor;
    }
    public void UpdateText()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        goldText.text = gold.ToString();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("GameArea");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }
    void OnResetButton()
    {
        score = 0;
        hp = 3;
        gold = 0;
        LoadGame();
    }
}
