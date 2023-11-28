using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestoreButton : MonoBehaviour
{
    public HealthRestoreUpgrade healthRestoreUpgrade;
    public GameManager manager;
    public string plantTag = "Plant"; 

    public void ApplyHealthRestoreUpgrade()
    {
        int cost = 5; 
        if (manager.getScore() >= cost)
        {
            // Find all active Flower objects with the specified tag
            GameObject[] plantObjects = GameObject.FindGameObjectsWithTag(plantTag);

            // Apply the health restore upgrade to each flower
            foreach (GameObject plantObject in plantObjects)
            {
                Flower flower = plantObject.GetComponent<Flower>();
                BlockerPlant blockerPlant = plantObject.GetComponent<BlockerPlant>();
                
                if (flower != null)
                {
                    healthRestoreUpgrade.Apply(plantObject);
                }
                else if (blockerPlant != null)
                {
                    healthRestoreUpgrade.Apply(plantObject);
                }
            }

            // Subtract the cost from the player's score
            manager.AddPoints(-cost);
        }
        else
        {
            Debug.LogWarning("GameManager score is insufficient.");
        }
    }
}

