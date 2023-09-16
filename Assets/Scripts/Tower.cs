using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectilePraticle;
    

    public Waypoint baseWayPoint;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemies = sceneEnemies[0].transform;

        foreach(EnemyDamage enemyDamage in sceneEnemies)
        {
            closestEnemies = GetClosest(closestEnemies, enemyDamage.transform);
        }

        targetEnemy = closestEnemies;
    }

    private Transform GetClosest(Transform transform1, Transform transform2)
    {
        var distanceA = Vector3.Distance(transform.position, transform1.position);
        var distanceB = Vector3.Distance(transform.position, transform2.position);

        if(distanceA < distanceB)
        {
            return transform1;
        }
        
            return transform2;
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
