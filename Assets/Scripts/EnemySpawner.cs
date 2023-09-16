using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform deathEnemyClone;
    [SerializeField] Text trackEnemy;
    [SerializeField] AudioClip enemySpawnAudio;
    int score = 1;
    
    void Start()
    {
        StartCoroutine(AlwaysSpawn());
        trackEnemy.text = score.ToString();
    }
    IEnumerator AlwaysSpawn()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(enemySpawnAudio);
            var spawnEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnEnemy.transform.parent = deathEnemyClone;
            yield return new WaitForSeconds(secondsBetweenSpawns);
            AddScore();
        }
    }

    private void AddScore()
    {
        score++;
        trackEnemy.text = score.ToString();
    }

}
