using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgradeButton : MonoBehaviour
{
    public FireRateUpgrade fireRateUpgrade;
    public Flower flower;

    public Flower flowerTwo;
    
    public GameManager manager;
	public AudioScript audioScript;

    public void ApplyFireRateUpgrade()
    {
        int cost = 7;
        if (flower != null && manager.getScore() >= cost)
        {
            fireRateUpgrade.Apply(flower.gameObject);
            manager.AddPoints(-cost);
			audioScript.playConfirmUpgrade();
        }
        else
        {
            audioScript.playInsufficentFunds();
            Debug.LogWarning("Flower GameObject is not assigned or not enough score.");
        }
    }
}
