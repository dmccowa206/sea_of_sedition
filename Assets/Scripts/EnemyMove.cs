using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rngRange = 5f;
    float rngDestX, rngDestY;
    Vector2 moveDest, minBounds, maxBounds;
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

    void Update()
    {
        Move(moveDest);
        PosCheck();
    }
    void Move(Vector3 dest)
    {
        //rngmove
        float delta = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, dest, delta);
        if (transform.position == dest)
        {
            rngDestX = Random.Range(-rngRange, rngRange);
            rngDestY = Random.Range(-rngRange, rngRange);
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
    }void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            //destroy coin and add enemy threat
            Destroy(other.gameObject);
        }
    }
}
