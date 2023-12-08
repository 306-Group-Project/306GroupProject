using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillUpgradeButton : MonoBehaviour
{
   public HealthBuff healthBuff;
   public GameObject windMill;
   public GameManager manager;
   
   public int cost = 5;

   public void ApplyHealthBuff()
   {
      if (windMill != null)
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
