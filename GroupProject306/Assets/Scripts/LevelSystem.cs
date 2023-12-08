using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LevelSystem : MonoBehaviour
{
    /*
     * Holds and tracks how many enemies have spawned and how many enemies have died
     * and creates levels with scaling difficulty. Generates variable for the amount of enemies
     * per level based on what level the game is on. Activates spawners to spawn them
     * until enough enemies have been defeated
     * Variables
     * enemiesInLevel: int, number of enemies in the level
     * enemyCount: int, number of enemies spawned
     * enemyAlive: int, number of enemies alive
     * levelCount: int, the level the player is on
     * spawnEnemies: boolean, determines whether enemies should be spawning or not
     */
    [SerializeField] public GameObject enemybar;
    [SerializeField] private int enemyCount;
    [SerializeField] public int enemyAlive;
    [SerializeField] private int levelCount;
    [SerializeField] public int enemiesInLevel;
    [SerializeField] private Boolean spawnEnemies;
    [SerializeField] private float levelTimer = 60.0f;
    [SerializeField] public GameManager gManager;
    // Start is called before the first frame update
    void Start()
    {
        levelCount = 1;
        GenerateEnemies();
        
    }

    // Update is called once per frame
    void Update()
    {
        // when the enemies spawned is at the amount desired, stop spawning enemies
        if (enemyCount >= enemiesInLevel)
        {
            spawnEnemies = false;

            // if all enemies have been defeated move to the next level
            if (enemyAlive <= 0)
            {
                enemyCount = 0;
                levelCount++;
                GenerateEnemies();
                gManager.GetComponent<GameManager>().SetLevelText(levelCount);

                // opens store
                gManager.GetComponent<GameManager>().OpenShopMenu();
                enemybar.GetComponent<EnemyWaveBar>().resetMax(enemiesInLevel);
                spawnEnemies = true;


            }

        }
        else
        {
            spawnEnemies = true;
        }
    }

    // increases enemiesInLevel based off of levelCount
    public void GenerateEnemies()
    {
        enemiesInLevel = 5 + (levelCount * (UnityEngine.Random.Range(2, 4)));
        enemyAlive = enemiesInLevel;
    }

    // returns true if level has begun, false if all enemies have been defeated
    public Boolean spawnerStatus()
    {
        return spawnEnemies;
    }

    // increases the amount of enemies that have spawned
    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

    // decreases the amount of enemies that are alive
    public void DecreaseLivingEnemies()
    {
        enemyAlive--;
        enemybar.GetComponent<EnemyWaveBar>().SetEnemies(enemyAlive);

    }

    public int getLevel()
    {
        return levelCount;
    }


}

