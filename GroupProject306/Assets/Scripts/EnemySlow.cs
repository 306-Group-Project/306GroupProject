using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/SlowEnemy")]
public class SlowEnemy : UpgradeEffect
{
    public float slowdownMultiplier = 0.5f; // Adjust the multiplier as needed
    public float duration = 5.0f; // Adjust the duration as needed

    public override void Apply(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Calculate the new movement speed based on the multiplier
            float newMoveSpeed = enemy.moveSpeed * slowdownMultiplier;

            // Apply the new movement speed
            enemy.moveSpeed = newMoveSpeed;

            // Start a coroutine to revert the speed after a certain duration
            target.GetComponent<MonoBehaviour>().StartCoroutine(RevertSpeedAfterDuration(enemy));
        }
        else
        {
            Debug.LogWarning("SlowEnemy upgrade applied to a non-enemy GameObject.");
        }
    }

    IEnumerator RevertSpeedAfterDuration(Enemy enemy)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Revert movement speed to original speed
        enemy.moveSpeed = enemy.originalMoveSpeed; 
    }
}
