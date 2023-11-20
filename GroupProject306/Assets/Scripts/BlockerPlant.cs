using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerPlant : MonoBehaviour
{
   
    public float health = 100.0f;
    public float damage = 10.0f;
    public float damageTime;
    public float damageRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

   

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (Time.time >= damageTime)
            {
                health -= damage;
                damageTime = Time.time + damageRate;

                this.GetComponent<Renderer>().material.color = new Color(0.64f, 0.16f, 0.03f);
            }
        }
    }

    public void ReduceDamage(float damageDecrease)
    {
        damage -= damageDecrease;
    }

    public void ResetHealth()
    {
        health = 100.0f;
    }

    public void SetHealth(float maxHealth)
    {
        health = maxHealth;
    }
}
