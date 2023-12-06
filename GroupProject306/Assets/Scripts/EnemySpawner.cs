using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bunny;
    public GameObject bug;
    public GameObject bear;


    [Range(0, Mathf.PI)] public float spawnArcRange = Mathf.PI/2;
    [Range(0, 2 * Mathf.PI)] public float angleOffset;
    [Range(1, 10)] public float spawnerDistanceFromWindmill = 2.0f;

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
	                if (levelManager.GetComponent<LevelSystem>().getLevelCount() <= 2)
	                {
		                (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
			                levelManager.transform;
		                levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();

	                }
	                else if (levelManager.GetComponent<LevelSystem>().getLevelCount() > 2 && levelManager.GetComponent<LevelSystem>().getLevelCount() <= 5)
	                {

		                float rand = Random.Range(0, 10);
		                if (rand < 8)

	                int rand = Random.Range(0, 11);
	                if (levelManager.GetComponent<LevelSystem>().getLevel() <= 3)
	                {
		                (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
			                levelManager.transform;
		                levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
		                Debug.Log("rand = "+ rand);
	                } else if (levelManager.GetComponent<LevelSystem>().getLevel() > 3 && levelManager.GetComponent<LevelSystem>().getLevel() <= 6)
	                {
		                if (rand < 7)
		                {
			                (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
				                levelManager.transform;
			                levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
			                Debug.Log("rand = "+ rand);
		                }
		                else
		                {
			                (Instantiate(bear, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
				                levelManager.transform;
			                levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
			                Debug.Log("rand = "+ rand);
		                }
	                }
	                else
	                {
		                if (rand < 2)
		                {
			                (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
				                levelManager.transform;
			                levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
			                Debug.Log("rand = "+ rand);
		                }
		                else
		                {
			                (Instantiate(bear, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
				                levelManager.transform;
			                levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
			                Debug.Log("rand = "+ rand);
		                }
	                }
                }
                spawnTimer = Time.time + spawnRate;
            }

    }
}
