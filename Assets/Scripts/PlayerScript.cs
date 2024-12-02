using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float InvincibilityTime = 3f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBot;
    Vector2 minBounds, maxBounds, bottomEdge;
    Shooter shooter;
    GameManager gm;
    bool invincible = true, controllable = true;
    float invTime = 0f;
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
        if (transform.position.y < bottomEdge.y)
        {
            gm.LoadShop();
        }
    }
    void Survive()
    {
        gm.difficultyLevel += Time.deltaTime * gm.GetScalor();
        if (invincible)
        {
            invTime += Time.deltaTime;
            if (invTime >= InvincibilityTime)
            {
                invincible = false;
                invTime = 0;
            }
            
        }
        if (gm.hp <= 0)
        {
            //GameOver
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
        bottomEdge = cam.ViewportToWorldPoint(new Vector2(0,-0.09f));
    }
    void UpdateOverlay()
    {
        gm.UpdateText();
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
            if (!invincible)
            {
                gm.hp --;
            }
        }
    }
}
