using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpd = 5f;
    [SerializeField] float projectileLifetime = 5f;
    Coroutine fireCoroutine;
    [HideInInspector]public bool isFiring;
    GameManager gm;
    [Header("AI")]
    [SerializeField] bool isAI;
    private float fireRateVariance = 0.7f;
    [SerializeField] float aiFireRate = 10f;
    private float fireRate, minFireRate = 1f;
    void Start()
    {
        gm = DontDestroyOnLoadManager.GetGameManager();
        if(isAI && gm.enemyWepLvl >= 1)
        {
            isFiring = true;
        }
    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpd;
            }
            if(isAI)
            {
                float aiFireRateRandomized = Random.Range(aiFireRate - fireRateVariance,
                    aiFireRate + fireRateVariance) + 1;
                fireRate = Mathf.Clamp(aiFireRateRandomized, minFireRate, float.MaxValue);
                instance.tag = "EnemyBullet";
            }
            else
            {
                fireRate = gm.fireRate;
                instance.tag = "PlayerBullet";
            }
            Destroy(instance, projectileLifetime);
            // audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(fireRate);
        }
    }
}
