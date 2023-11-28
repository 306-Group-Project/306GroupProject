using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgradeButton : MonoBehaviour
{
    public FireRateUpgrade fireRateUpgrade;
    public Flower flower;

    public Flower flowerTwo;
    public Flower flowerThree;
    public GameManager manager;

    public void ApplyFireRateUpgrade()
    {
        int cost = 5;
        if (flower != null && manager.getScore() >= cost)
        {
            fireRateUpgrade.Apply(flower.gameObject);
            manager.AddPoints(-cost);
        }
        else
        {
            Debug.LogWarning("Flower GameObject is not assigned or not enough score.");
        }
    }
}
