using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    Vector2 rawInput;
    float moveSpeed;
    [SerializeField] float InvincibilityTime = 3f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBot;
    Vector2 minBounds, maxBounds, bottomEdge;
    Shooter shooter;
    GameManager gm;
    [SerializeField] bool invincible = true;
    bool controllable = true;
    [SerializeField] float invTime = 0f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] Canvas gameOverOverlay;
    [SerializeField] Slider hpSlider;
    SpriteRenderer sr;
    Color tmp;
    void Awake()
    {
        shooter = GetComponent<Shooter>();
        gm = DontDestroyOnLoadManager.GetGameManager();
    }
    void Start()
    {
        gm = DontDestroyOnLoadManager.GetGameManager();
        InitBounds();//Set playable area by cam bounds
        moveSpeed = gm.playerSpeed;
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        tmp = sr.color;
    }
    void Update()
    {
        moveSpeed = gm.playerSpeed;
        Move();
        Survive();
        UpdateOverlay();
    }

    private void Move()
    {
        Vector2 delta = moveSpeed * Time.deltaTime * rawInput;//move via Input System
        Vector2 newPos = new()
        {
            x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight),
            y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBot, maxBounds.y - paddingTop)
        };
        transform.position = newPos;
        if (transform.position.y < bottomEdge.y)
        {
            gm.LoadShop();
        }
    }
    void Survive()
    {
        gm.difficultyLevel += Time.deltaTime * gm.GetScalor();
        if (gm.hp <= 0)
        {
            //GameOver
            gameOverOverlay.gameObject.SetActive(true);
            controllable = false;
            rawInput = new Vector2(0f,0f);
        }
        else if (invincible)
        {
            invTime += Time.deltaTime;
            if (invTime >= InvincibilityTime)
            {
                tmp.a = 1f;
                sr.color = tmp;
                invincible = false;
                invTime = 0;
            }
            else
            {
                tmp.a *= -1;
                sr.color = tmp;
            }
        }
    }

    void OnMove(InputValue value)//get move input
    {
        if (controllable)
        {
            rawInput = value.Get<Vector2>();
        }
    }
    void OnFire(InputValue value)//shoot via input system NOT USABLE YET
    {
        if(shooter != null && controllable)
        {
            shooter.isFiring = value.isPressed;
        }
    }
    void InitBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0,-0.1f));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1,1));
        bottomEdge = cam.ViewportToWorldPoint(new Vector2(0,-0.09f));
    }
    void UpdateOverlay()
    {
        UpdateText();
        hpSlider.value = (float)gm.hp / gm.hpMax;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            //get score and gold
            gm.score += 100;
            gm.gold += gm.goldVal;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Enemy" || other.tag == "EnemyBullet")
        {
            //damage
            if (!invincible)
            {
                gm.hp --;
                invincible = true;
            }
            if (other.tag == "EnemyBullet")
            {
                Destroy(other);
            }
        }
    }
    void UpdateText()
    {
        // textList = FindObjectsOfType<TextMeshProUGUI>();
        
        scoreText.text = gm.score.ToString();
        highScoreText.text = gm.highScore.ToString();
        goldText.text = gm.gold.ToString();
    }
    public void OnResetClick()
    {
        gameOverOverlay.gameObject.SetActive(false);
        gm.OnResetButton();
    }
    public void OnQuit()
    {
        gameOverOverlay.gameObject.SetActive(false);
        gm.LoadMenu();
    }
}
