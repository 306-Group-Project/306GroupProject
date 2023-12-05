using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/HealthRestoreUpgrade")]
public class HealthRestoreUpgrade : UpgradeEffect
{
    public float healthToRestore;

    public override void Apply(GameObject target)
    {
        Debug.Log("Apply method called for HealthRestoreUpgrade.");

        if (target != null)
        {
            Flower flower = target.GetComponent<Flower>();
            BlockerPlant blockerPlant = target.GetComponent<BlockerPlant>();

            if (flower != null)
            {
                Debug.Log("Flower component found.");
                // Apply the upgrade to the Flower
                flower.ApplyHealthRestoreUpgrade(healthToRestore);
            }
            else if (blockerPlant != null)
            {
                Debug.Log("BlockerPlant component found.");
                // Apply the upgrade to the BlockerPlant
                blockerPlant.ApplyHealthRestoreUpgrade(healthToRestore);
            }
            else
            {
                Debug.LogWarning("HealthRestoreUpgrade applied to a GameObject without a Flower or BlockerPlant component.");
            }
        }
        else
        {
            Debug.LogWarning("HealthRestoreUpgrade applied to a null GameObject.");
        }
    }

}
