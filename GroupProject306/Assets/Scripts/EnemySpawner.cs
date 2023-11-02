using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;

    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if(Time.time > spawnTimer)
        {
            Vector3 spawnPosition = transform.position;

            // Instantiate the enemy at the spawner's position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            spawnTimer = Time.time + spawnRate;
        }
    }
}
