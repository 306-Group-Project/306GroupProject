using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public UpgradeEffect upgradeEffect;

    public void ApplyUpgrade()
    {
        upgradeEffect.Apply(gameObject);
    }

}
