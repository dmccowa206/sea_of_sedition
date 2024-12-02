using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBot;
    [Header("Game Parameters")]
    [SerializeField] float difficultyScalor = 0.05f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI goldText;
    Vector2 minBounds, maxBounds;
    Shooter shooter;
    GameManager gm;
    void Awake()
    {
        shooter = GetComponent<Shooter>();
        gm = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        InitBounds();//Set playable area by cam bounds
    }
    void Update()
    {
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
    }
    void Survive()
    {
        gm.difficultyLevel += Time.deltaTime * difficultyScalor;
    }

    void OnMove(InputValue value)//get move input
    {
        rawInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value)//shoot via input system NOT USABLE YET
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
    void InitBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0,-0.1f));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1,1));
    }
    void UpdateOverlay()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            //get score and gold
            gm.score += 100;
            gm.gold ++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Enemy")
        {
            //damage
            gm.hp --;
            if (gm.hp <= 0)
            {
                //GameOver
            }
        }
    }
}
