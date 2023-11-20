using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;

    public GameObject spawner;

    // Level Manager object
    public GameObject levelManager;

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {

            if (Time.time > spawnTimer)
            {
                Vector3 spawnPosition = transform.position;

                // Instantiate the enemy at the spawner's position
                //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // this should spawn in the enemies as children of the level system
                if (levelManager.GetComponent<LevelSystem>().spawnerStatus())
                {
                    (Instantiate(enemyPrefab, spawnPosition, Quaternion.identity) as GameObject).transform.parent = levelManager.transform;
                    levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
                }
                spawnTimer = Time.time + spawnRate;
            }

    }
}
