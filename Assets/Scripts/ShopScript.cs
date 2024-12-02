using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [Header("Prices")]
    [SerializeField] int heal = 5;
    [SerializeField] int hpUp = 15;
    [SerializeField] int weapon = 10;
    [SerializeField] int speed = 10;
    [SerializeField] int sabotage = 10;
    [SerializeField] int damage = 10;
    [SerializeField] int fireRate = 10;

    [Header("Button Text")]
    [SerializeField] TextMeshProUGUI healBtn;
    [SerializeField] TextMeshProUGUI hpUpBtn;
    [SerializeField] TextMeshProUGUI wepBtn;
    [SerializeField] TextMeshProUGUI dmgBtn;
    [SerializeField] TextMeshProUGUI fireRateBtn;
    [SerializeField] TextMeshProUGUI spdBtn;
    [SerializeField] TextMeshProUGUI saboBtn;
    [Header("Buttons")]
    [SerializeField] Button healButton;
    [SerializeField] Button hpUpButton;
    [SerializeField] Button weaponButton;
    [SerializeField] Button damageButton;
    [SerializeField] Button fireRateButton;
    [SerializeField] Button speedButton;
    [SerializeField] Button sabotageButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject upgradeBtns;
    GameManager gm;
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        healBtn.text = "Heal 1 HP\n" + heal + " Gold";
        hpUpBtn.text = "Increase Max HP\n" + hpUp + " Gold";
        wepBtn.text = "Add Weapons to Your Ship\n" + weapon + " Gold";
        spdBtn.text = "Increase Your Speed\n" + speed + " Gold";
        saboBtn.text = "Sabotage the Pirates\n" + sabotage + " Gold";
        dmgBtn.text = "Increase Your Weapon Damage\n" + damage + " Gold";
        dmgBtn.text = "Increase Your Fire Rate\n" + fireRate + " Gold";
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
        }
    }
    void OnBuyDamage()
    {
        if (gm.gold >= damage)
        {
            gm.wepLvl ++;
            gm.gold -= damage;
            damage += damage * 2 / 3;
        }
    }
    void OnBuyFireRate()
    {
        if (gm.gold >= fireRate)
        {
            gm.wepFireRate *= 0.9f;
            gm.gold -= fireRate;
            fireRate += fireRate * 3 / 4;
        }
    }
    void OnBuySpeed()
    {
        if (gm.gold >= speed)
        {
            gm.playerSpeed *= 1.1f;
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
