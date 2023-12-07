using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bunny;
    public GameObject bug;
    public GameObject bear;


    [Range(0, 2 * Mathf.PI)] public float spawnArcRange = Mathf.PI / 2;
    [Range(0, 2 * Mathf.PI)] public float angleOffset;
    [Range(1, 10)] public float spawnerDistanceFromWindmill = 2.0f;

    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;

    public GameObject spawner;

    // Level Manager object
    public GameObject levelManager;

    private void Start()
    {
        angleOffset = Random.Range(0, 2 * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {

        if (Time.time > spawnTimer)
        {
            int level = levelManager.GetComponent<LevelSystem>().getLevel();

            // level 2 and lower, quarter circle
            if (level <= 2)
            {
                spawnArcRange += 0;
            }

            // level 3 and 4, half circle
            else if(level <= 4 && level >= 3)
            {
                spawnArcRange = Mathf.PI;
            }

            // level 5 and 6, three quarter circle
            else if (level <= 6 && level >= 5)
            {
                spawnArcRange = Mathf.PI + Mathf.PI / 2;
            }

            // all other levels full circle
            else
            {
                spawnArcRange = 2 * Mathf.PI;
            }

            float randAngle = Random.value * spawnArcRange;
            randAngle += angleOffset;

            float x = Mathf.Cos(randAngle) * spawnerDistanceFromWindmill;
            float z = Mathf.Sin(randAngle) * spawnerDistanceFromWindmill;

            spawner.transform.position = new Vector3(x, 0.2f, z);

            Vector3 spawnPosition = transform.position;

            // this should spawn in the enemies as children of the level system
            if (levelManager.GetComponent<LevelSystem>().spawnerStatus())
            {
                if (levelManager.GetComponent<LevelSystem>().getLevel() <= 2)
                {
                    (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
                        levelManager.transform;
                    levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();

                }
                else if (levelManager.GetComponent<LevelSystem>().getLevel() > 2 && levelManager.GetComponent<LevelSystem>().getLevel() <= 5)
                {

                    float rand = Random.Range(0, 10);

                    // just bunnys for first three levels
                    if (levelManager.GetComponent<LevelSystem>().getLevel() <= 3)
                    {
                        (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
                            levelManager.transform;
                        levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
                       
                    }

                    // from level 4 to 6 get bunnys and bears, mostly bunnys
                    else if (levelManager.GetComponent<LevelSystem>().getLevel() > 3 && levelManager.GetComponent<LevelSystem>().getLevel() <= 6)
                    {
                        if (rand < 7)
                        {
                            (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
                                levelManager.transform;
                            levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
                        }
                        else
                        {
                            (Instantiate(bear, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
                                levelManager.transform;
                            levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
                        }
                    }

                    // level 7 and above get mostly bears
                    else
                    {
                        if (rand < 2)
                        {
                            (Instantiate(bunny, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
                                levelManager.transform;
                            levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();   
                        }
                        else
                        {
                            (Instantiate(bear, spawnPosition, Quaternion.identity) as GameObject).transform.parent =
                                levelManager.transform;
                            levelManager.GetComponent<LevelSystem>().IncreaseEnemyCount();
                        }
                    }
                }

                spawnTimer = Time.time + spawnRate;
            }
        }
    }
}
