using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectilePraticle;

    // Update is called once per frame
    void Update()
    {
        if(targetEnemy)
        {
            LookAtEnemy();
            ShootRange();
        }
        else
        {
            Shoot(false);
        }
    }

    private void ShootRange()
    {
        float enemyDistance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (enemyDistance <= attackRange)
        {
            Shoot(true);
        }
        else
            Shoot(false);
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectilePraticle.emission;
        emissionModule.enabled = isActive;
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
