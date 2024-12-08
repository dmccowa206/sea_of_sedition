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
            gm.enemyWepLvl = diffLevel / 10;
            gm.enemySize = (diffLevel/50f) + 1f;
            gm.enemySpeed = diffLevel / 20f + 1.5f;
            currentlvl = diffLevel;
        }
        if (diffLevel % 20 == 0)
        {
            gm.goldVal++;
        }
    }
}
