using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillUpgradeButton : MonoBehaviour
{
   public HealthBuff healthBuff;
   public GameObject windMill;
   public GameManager manager;

   public void ApplyHealthBuff()
   {
      int cost = 5;
      if (windMill != null && manager.getScore() >= cost)
      {
         healthBuff.Apply(windMill);
         manager.AddPoints(-cost);
      }
      else
      {
         Debug.LogWarning("WindMill Gameobject is not assigned.");
      }
   }
}
