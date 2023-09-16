using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] AudioClip enemyDamageAudio;
    [SerializeField] AudioClip enemydeathAudio;

    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        var deathvfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        deathvfx.Play();
        Destroy(deathvfx.gameObject, deathvfx.main.duration);
        AudioSource.PlayClipAtPoint(enemydeathAudio, Camera.main.transform.position);
        Destroy(gameObject); 
    }

    void ProcessHit()
    {
        myAudioSource.PlayOneShot(enemyDamageAudio);
        hitPoints = hitPoints - 2;
        hitParticle.Play();
    }
}
