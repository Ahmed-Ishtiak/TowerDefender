using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 2;
        hitParticle.Play();
    }
}
