using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/HealthBuff")]
public class HealthBuff : UpgradeEffect
{
  public float amount;

  public override void Apply(GameObject target)
  {
    Debug.Log("Apply method called."); // Add this line

    if (target != null)
    {
      WindMill windMill = target.GetComponent<WindMill>();
      if (windMill != null)
      {
        Debug.Log("WindMill component found."); // Add this line

        windMill.health += amount;
        Debug.Log("Health increased by " + amount + ". New health: " + windMill.health); // Add this line
      }
      else
      {
        Debug.LogWarning("HealthBuff upgrade applied to a GameObject without a WindMill component.");
      }
    }
    else
    {
      Debug.LogWarning("HealthBuff upgrade applied to a null GameObject.");
    }
  }
} 
