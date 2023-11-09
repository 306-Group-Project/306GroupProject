using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindMillHealth : MonoBehaviour
{
    // variables for camera
    public GameObject cameraToFollow;
    // public variables for the healthbar and windmill hp
    public GameObject windMill;
    public Slider healthBar;
    public WindMill playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Windmill").GetComponent<WindMill>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.health;
        healthBar.value = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(-cameraToFollow.transform.position);
    }

    // updates the health bar to reflect hp
    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}
