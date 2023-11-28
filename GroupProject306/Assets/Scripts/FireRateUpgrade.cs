using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/FireRateUpgrade")]
public class FireRateUpgrade : UpgradeEffect
{
    public float multiplier = 1.5f;
    public float duration = 5.0f;

    public override void Apply(GameObject target)
    {
        Debug.Log("Apply method called for FireRateUpgrade.");

        if (target != null)
        {
            Flower flower = target.GetComponent<Flower>();
            if (flower != null)
            {
                Debug.Log("Flower component found.");

                flower.ApplyFireRateUpgrade(multiplier, duration);
                Debug.Log($"Fire rate increased by {multiplier} for {duration} seconds.");
            }
            else
            {
                Debug.LogWarning("FireRateUpgrade applied to a GameObject without a Flower component.");
            }
        }
        else
        {
            Debug.LogWarning("FireRateUpgrade applied to a null GameObject.");
        }
    }
}