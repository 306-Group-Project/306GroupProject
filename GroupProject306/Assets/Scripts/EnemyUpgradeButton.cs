using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpgradeButton : MonoBehaviour
{
    public EnemySlow enemySlow;
    public GameObject enemy;
    
    public void ApplyEnemySlow()
    {
        if (enemy != null)
        {
            enemySlow.Apply(enemy);
        }
        else
        {
            Debug.LogWarning("Enemy Gameobject is not assigned.");
        }
    }
}
