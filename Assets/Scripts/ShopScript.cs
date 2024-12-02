using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [Header("Prices")]
    [SerializeField] int heal = 5;
    [SerializeField] int hpUp = 15;
    [SerializeField] int weapon = 10;
    [SerializeField] int speed = 10;
    [SerializeField] int sabotage = 10;
    [Header("Buttons")]
    [SerializeField] TextMeshProUGUI healBtn;
    [SerializeField] TextMeshProUGUI hpUpBtn;
    [SerializeField] TextMeshProUGUI wepBtn;
    [SerializeField] TextMeshProUGUI spdBtn;
    [SerializeField] TextMeshProUGUI saboBtn;
    GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        healBtn.text = "Heal 1 HP\n" + heal + " Gold";
        hpUpBtn.text = "Increase Max HP\n" + hpUp + " Gold";
        wepBtn.text = "Upgrade Your Weapons\n" + weapon + " Gold";
        spdBtn.text = "Increase Your Speed\n" + speed + " Gold";
        saboBtn.text = "Sabotage the Pirates\n" + sabotage + " Gold";
    }
    void OnBuyLife()
    {
        if (gm.gold >= heal && gm.hp < gm.hpMax)
        {
            gm.hp ++;
            gm.gold -= heal;
            heal ++;
        }
    }
    void OnBuyMaxHP()
    {
        if (gm.gold >= hpUp)
        {
            gm.hpMax ++;
            gm.gold -= hpUp;
            hpUp += hpUp;
        }
    }
    void OnBuyWeapon()
    {
        if (gm.gold >= weapon)
        {
            gm.wepLvl ++;
            gm.gold -= weapon;
            weapon += weapon / 2;
        }
    }
    void OnBuySpeed()
    {
        if (gm.gold >= speed)
        {
            //playerspeed * 1.1
            gm.gold -= speed;
            speed += speed / 2;
        }
    }
    void OnSabotage()
    {
        if (gm.gold >= sabotage)
        {
            gm.difficultyLevel --;
            gm.gold -= sabotage;
            sabotage += sabotage / 3;
        }
    }
    void OnExit()
    {
        gm.LoadGame();
    }
}
