using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool rngMove = false;
    private float timeSinceSpawn = 0;
    [SerializeField] float initMoveDuration = 2f; 
    void Update()
    {
        if(rngMove)
        {
            MoveRandom();
        }
        else
        {
            MoveInit();
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
    void MoveInit()
    {
        //move in from edge
    }
}
