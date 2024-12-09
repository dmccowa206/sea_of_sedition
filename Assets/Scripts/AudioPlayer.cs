using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootClip;
    [SerializeField] [Range(0f, 1f)] float shootVol = 1f;
    [Header("Player Hit")]
    [SerializeField] AudioClip playerClip;
    [SerializeField] [Range(0f, 1f)] float pVol = 1f;
    [Header("Enemy Hit")]
    [SerializeField] AudioClip enemyClip;
    [SerializeField] [Range(0f, 1f)] float eVol = 1f;
    [Header("Gold Pickup")]
    [SerializeField] AudioClip goldClip;
    [SerializeField] [Range(0f, 1f)] float goldVol = 1f;
    [Header("Purchase")]
    [SerializeField] AudioClip buyClip;
    [SerializeField] [Range(0f, 1f)] float buyVol = 1f;


    public void PlayShootingClip()
    {
        PlayClip(shootClip,shootVol);
    }
    public void PlayPlayerHitClip()
    {
        PlayClip(playerClip, pVol);
    }
    public void PlayEnemyHitClip()
    {
        PlayClip(enemyClip, eVol);
    }
    public void PlayGoldClip()
    {
        PlayClip(goldClip, goldVol);
    }
    public void PlayBuyClip()
    {
        PlayClip(buyClip, buyVol);
    }
    public void PlayClip(AudioClip soundClip, float vol)
    {
        if(soundClip != null)
        {
            AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position, vol);
        }
    }
}
