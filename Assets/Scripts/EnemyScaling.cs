using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaling : MonoBehaviour
{
    int diffLevel = 0, currentlvl = 0;
    [SerializeField] float baseSpeed;
    GameManager gm;
    void Start()
    {
        gm = DontDestroyOnLoadManager.GetGameManager();
        diffLevel = (int)Math.Floor(gm.GetDifficultyLevel());
        EnemyScale();
    }
    void Update()
    {
        TierUp();
    }
    void TierUp()
    {
        diffLevel = (int)Math.Floor(gm.GetDifficultyLevel());
        if (diffLevel > currentlvl)
        {
            EnemyScale();
            if (diffLevel % 10 == 0)
            {
                gm.goldVal++;
            }
            currentlvl = diffLevel;
        }
    }
    void EnemyScale()
    {
        
        gm.enemyWepLvl = diffLevel / 10;
        gm.enemySize = (diffLevel/50f) + 1f;
        gm.enemySpeed = diffLevel / 30f + 1.5f;
    }
}
