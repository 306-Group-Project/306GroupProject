using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveBar : MonoBehaviour
{
    // public variables for the healthbar and windmill hp
    [SerializeField] public Slider enemyBar;
    [SerializeField] public LevelSystem enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.FindGameObjectWithTag("Levelsystem").GetComponent<LevelSystem>();
        enemyBar = GetComponent<Slider>();
        enemyBar.maxValue = enemyCount.enemiesInLevel;
        enemyBar.value = enemyCount.enemyAlive;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // updates the health bar to reflect hp
    public void SetEnemies(int enemies)
    {
        enemyBar.value = enemies;
    }

    public void resetMax(int maxEnemies)
    {
        enemyBar.maxValue = maxEnemies;
        enemyBar.value = maxEnemies;
    }
}
