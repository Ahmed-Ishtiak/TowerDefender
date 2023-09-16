using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem goalParticle;
    private void Start()
	{
		PathFinder pathFinder = FindObjectOfType<PathFinder>();
		var path = pathFinder.GetPath();
		StartCoroutine(PathFollower(path));
	}
	IEnumerator PathFollower(List<Waypoint>path)
	{
		
		foreach(Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f);
		}
		SelfDestruct();
	}
    private void SelfDestruct()
    {
        var deathvfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        deathvfx.Play();
        Destroy(deathvfx.gameObject, deathvfx.main.duration);
        Destroy(gameObject);
    }
}
