using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool rngMove = false;
    private float timeSinceSpawn = 0;
    [SerializeField] float initMoveDuration = 2f;
    int spawnSide;
    public void SetSpawnSide(int side)
    {
        spawnSide = side;
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
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
