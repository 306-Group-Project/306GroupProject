using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/HealthBuff")]
public class HealthBuff : UpgradeEffect
{
  public float amount;
  public override void Apply(GameObject target)
  {
    target.GetComponent<WindMill>().health += amount;
  }
}
