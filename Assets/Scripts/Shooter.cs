using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpd = 0.4f;
    [SerializeField] float projectileLifetime = 5f;
    Coroutine fireCoroutine;
    [HideInInspector]public bool isFiring;
    GameManager gm;
    [Header("AI")]
    [SerializeField] bool isAI;
    private float fireRateVariance = 1.7f;
    float aiFireRate = 5f;
    private float fireRate, minFireRate = 1f;
    Vector3 target;
    void Start()
    {
        gm = DontDestroyOnLoadManager.GetGameManager();
        if(isAI && gm.enemyWepLvl >= 1)
        {
            Invoke("ActivateShooting", 1f);
        }
    }
    void Update()
    {
        // fireRate = gm.wepFireRate;
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
            if (isAI)
            {
                target = FindAnyObjectByType<PlayerScript>().gameObject.transform.position - gameObject.transform.position;
            }
            else
            {
                target = WorldPosition.GetMouseWorldPos() - gameObject.transform.position;
            }
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = target * projectileSpd;
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
                fireRate = gm.wepFireRate;
                instance.tag = "PlayerBullet";
            }
            Destroy(instance, projectileLifetime);
            // audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(fireRate);
        }
    }
    void ActivateShooting()
    {
        isFiring = true;
    }
}
