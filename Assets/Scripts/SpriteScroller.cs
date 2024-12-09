using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpd;
    [SerializeField] int waveRate;
    [SerializeField] float waveSpeed;
    Vector2 offset;
    Material mat;
    float waveTimer = 0;
    void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        waveTimer += Time.deltaTime;
        if (waveTimer > waveRate)
        {
            moveSpd.x = Random.Range(-waveSpeed, waveSpeed);
            moveSpd.y = Random.Range(-waveSpeed, waveSpeed);
            waveTimer = 0;
        }
        offset = moveSpd * Time.deltaTime;
        mat.mainTextureOffset += offset;
    }

}
