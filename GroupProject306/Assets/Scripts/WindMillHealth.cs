using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindMillHealth : MonoBehaviour
{
    // public variables for the healthbar and windmill hp
    public GameObject windMill;
    public Slider healthBar;
    public float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = windMill.GetComponent<WindMill>().getHp();
        healthBar.maxValue = playerHealth;
        healthBar.value = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // updates the health bar to reflect hp
    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}
