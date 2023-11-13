using System;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private int enemyCount;
    [SerializeField] private int enemyAlive;
    [SerializeField] private int levelCount;
    [SerializeField] private int enemiesInLevel;
    [SerializeField] private Boolean spawnEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when the enemies spawned is at the amount desired, stop spawning enemies
        if (enemyCount == enemiesInLevel)
        {
            spawnEnemies = false;

            // if all enemies have been defeated move to the next level
            if (enemyAlive == 0)
            {
                enemyCount = 0;
                levelCount++;
                GenerateEnemies();
                //TODO: Works for now, make sure to add a wait period in between levels 
                // later
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
        enemiesInLevel = 10 + (levelCount * UnityEngine.Random.Range(1, 3));
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

    

}
