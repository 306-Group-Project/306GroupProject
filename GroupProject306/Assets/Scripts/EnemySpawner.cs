using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [Range(0, Mathf.PI)] public float spawnArcRange = Mathf.PI/2;
    [Range(0, 2 * Mathf.PI)] public float angleOffset;
    [Range(1, 10)] public float spawnerDistanceFromWindmill = 2.0f;

    [SerializeField] private float spawnRate = 2.0f;
	[SerializeField] private float initialDelay = 6.0f; // inital spawn delay 

    private float spawnTimer;
	private float initialDelayTimer; 
	private bool canSpawn = false; 

    public GameObject spawner;

    // Level Manager object
    public GameObject levelManager;

	void Start(){
		initialDelayTimer = initialDelay; 
	} 

    // Update is called once per frame
    void Update()
    {
		// count down the initial delay before eneimes start to spawn 
		if (initialDelayTimer > 0) 
		{
			initialDelayTimer -= Time.deltaTime; 
			if (initialDelayTimer <= 0)
			{	
				canSpawn = true; 
			}
		} 
		
		if (canSpawn)
		{
        SpawnEnemy();
		}
    }

    private void SpawnEnemy()
    {

            if (Time.time > spawnTimer)
            {
                Vector3 spawnPosition = transform.position;

            // Instantiate the enemy at the spawner's position
            //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            //Vector2 randSpawnerSpot = Random.insideUnitCircle.normalized * 2.0f;

            //spawner.transform.position = new Vector3(randSpawnerSpot.x, 0.3f, randSpawnerSpot.y);

            float randAngle = Random.value * spawnArcRange;
            randAngle += angleOffset;
            
            float x = Mathf.Cos(randAngle) * spawnerDistanceFromWindmill;
            float z = Mathf.Sin(randAngle) * spawnerDistanceFromWindmill;

            Debug.DrawLine(Vector3.zero, new Vector3(x, 0.2f, z), Color.red, 1f);

            spawner.transform.position = new Vector3 (x, 0.2f, z);

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
