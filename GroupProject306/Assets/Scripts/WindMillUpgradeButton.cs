using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillUpgradeButton : MonoBehaviour
{
   public HealthBuff healthBuff;
   public GameObject windMill;

   public void ApplyHealthBuff()
   {
      if (windMill != null)
      {
         healthBuff.Apply(windMill);
      }
      else
      {
         Debug.LogWarning("WindMill Gameobject is not assigned.");
      }
   }
}
