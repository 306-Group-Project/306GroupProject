using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillUpgradeButton : MonoBehaviour
{
   public HealthBuff healthBuff;
   public GameObject windMill;
   public GameObject healthbar;
   public GameManager manager;

   public void ApplyHealthBuff()
   {
      int cost = 5;
      if (windMill != null && manager.getScore() >= cost)
      {
         healthBuff.Apply(windMill);
         manager.AddPoints(-cost);
         healthbar.GetComponent<WindMillHealth>().SetHealth(manager.windMill.health);
      }
      else
      {
         Debug.LogWarning("WindMill Gameobject is not assigned.");
      }
   }
}
