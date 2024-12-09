using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float moveSpeed = 1f;
    int enemyHp = 1;
    [SerializeField] float rngRange = 5f;
    float rngDestX, rngDestY;
    Vector2 moveDest, minBounds, maxBounds;
    GameManager gm;
    AudioPlayer audioPlayer;
    public void SetInitDest(Vector2 idest)
    {
        moveDest = idest;
    }
    public void SetMinBounds(Vector2 minB)
    {
        minBounds = minB;
    }
    public void SetMaxBounds(Vector2 maxB)
    {
        maxBounds = maxB;
    }
    public void SetSpeed(float spd)
    {
        moveSpeed = spd;
    }
    void Start()
    {
        gm = DontDestroyOnLoadManager.GetGameManager();
        enemyHp = (int)Math.Floor(gm.GetDifficultyLevel() / 10f) + 1;
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }

    void Update()
    {
        Move(moveDest);
        PosCheck();
        SetSpeed(gm.enemySpeed);
    }
    void Move(Vector3 dest)
    {
        //rngmove
        float delta = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, dest, delta);
        if (transform.position == dest)
        {
            rngDestX = UnityEngine.Random.Range(-rngRange, rngRange);
            rngDestY = UnityEngine.Random.Range(-rngRange, rngRange);
            moveDest = new Vector2(rngDestX, rngDestY);
        }
    }
    void PosCheck()
    {
        if (transform.position.x < minBounds.x)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > maxBounds.x)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < minBounds.y)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > maxBounds.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            //destroy coin and add enemy threat
            Destroy(other.gameObject);
            gm.PirateLoot();
        }
        else if (other.tag == "PlayerBullet")
        {
            enemyHp -= gm.wepLvl;
            Destroy(other.gameObject);
            audioPlayer.PlayEnemyHitClip();
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
                gm.score += 500;
            }
        }
    }
}
