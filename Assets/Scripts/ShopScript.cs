using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    [Header("Button Text")]
    [SerializeField] TextMeshProUGUI healBtn;
    [SerializeField] TextMeshProUGUI hpUpBtn;
    [SerializeField] TextMeshProUGUI wepBtn;
    [SerializeField] TextMeshProUGUI dmgBtn;
    [SerializeField] TextMeshProUGUI fireRateBtn;
    [SerializeField] TextMeshProUGUI spdBtn;
    [SerializeField] TextMeshProUGUI saboBtn;
    [SerializeField] TextMeshProUGUI statusText;
    [Header("Buttons")]
    // [SerializeField] Button healButton;
    // [SerializeField] Button hpUpButton;
    [SerializeField] Button weaponButton;
    // [SerializeField] Button damageButton;
    // [SerializeField] Button fireRateButton;
    // [SerializeField] Button speedButton;
    // [SerializeField] Button sabotageButton;
    // [SerializeField] Button exitButton;
    [SerializeField] GameObject upgradeBtns;
    GameManager gm;
    void Start()
    {
        gm = DontDestroyOnLoadManager.GetGameManager();
    }
    void Update()
    {
        if (gm.wepLvl == 0)
        {
            weaponButton.gameObject.SetActive(true);
            upgradeBtns.gameObject.SetActive(false);
        }
        healBtn.text = "Heal 1 HP\n" + gm.heal + " Gold";
        hpUpBtn.text = "Increase Max HP\n" + gm.hpUp + " Gold";
        wepBtn.text = "Add Weapons to Your Ship\n" + gm.weapon + " Gold";
        spdBtn.text = "Increase Your Speed\n" + gm.speed + " Gold";
        saboBtn.text = "Sabotage the Pirates\n" + gm.sabotage + " Gold";
        dmgBtn.text = "Increase Your Weapon Damage\n" + gm.damage + " Gold";
        fireRateBtn.text = "Increase Your Fire Rate\n" + gm.fireRate + " Gold";
        statusText.text = "HP: " + gm.hp + " / " + gm.hpMax + "\nGold: " + gm.gold;
    }
    public void OnBuyLife()
    {
        if (gm.gold >= gm.heal && gm.hp < gm.hpMax)
        {
            gm.hp ++;
            gm.gold -= gm.heal;
            gm.heal ++;
        }
    }
    public void OnBuyMaxHP()
    {
        if (gm.gold >= gm.hpUp)
        {
            gm.hpMax ++;
            gm.hp ++;
            gm.gold -= gm.hpUp;
            gm.hpUp += gm.hpUp;
        }
    }
    public void OnBuyWeapon()
    {
        if (gm.gold >= gm.weapon)
        {
            gm.wepLvl ++;
            gm.gold -= gm.weapon;
            weaponButton.gameObject.SetActive(false);
            upgradeBtns.gameObject.SetActive(true);
        }
    }
    public void OnBuyDamage()
    {
        if (gm.gold >= gm.damage)
        {
            gm.wepLvl ++;
            gm.gold -= gm.damage;
            gm.damage += gm.damage * 2 / 3;
        }
    }
    public void OnBuyFireRate()
    {
        if (gm.gold >= gm.fireRate)
        {
            gm.wepFireRate *= 0.9f;
            gm.gold -= gm.fireRate;
            gm.fireRate += gm.fireRate * 3 / 4;
        }
    }
    public void OnBuySpeed()
    {
        if (gm.gold >= gm.speed)
        {
            gm.playerSpeed *= 1.1f;
            gm.gold -= gm.speed;
            gm.speed += gm.speed / 2;
        }
    }
    public void OnSabotage()
    {
        if (gm.gold >= gm.sabotage)
        {
            gm.difficultyLevel --;
            gm.gold -= gm.sabotage;
            gm.sabotage += gm.sabotage / 3;
        }
    }
    public void OnExit()
    {
        gm.LoadGame();
    }
}
