using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool rngMove = false;
    private float timeSinceSpawn = 0;
    [SerializeField] float initMoveDuration = 2f;
    [SerializeField] float moveSpeed = 6f;
    int spawnSide;
    float rngDestX, rngDestY;
    Vector2 moveDest;
    bool initFirst = true;
    public void SetSpawnSide(int side)
    {
        spawnSide = side;
    }public void SetInitDest(Vector2 idest)
    {
        moveDest = idest;
    }

    void Update()
    {
        if(rngMove)
        {
            MoveRandom();
        }
        else
        {
            MoveInit(spawnSide);
            if (timeSinceSpawn >= initMoveDuration)
            {
                rngMove = true;
            }
        }
    }
    void MoveRandom()
    {
        //rngmove
    }
    void MoveInit(int side)
    {
        //move in from edge
        switch (side)
        {
            case 0:
                if(initFirst)
                {
                }
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                Debug.Log("An invalid side was passed in.");
                break;
        }
    }
}
