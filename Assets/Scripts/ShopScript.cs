using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void OnBuyLife()
    {
        gm.hp ++;
    }
    void OnBuyWeapon()
    {
    }
    void OnBuySpeed()
    {
    }
    void OnSabotage()
    {
    }
    void OnExit()
    {
    }
}
