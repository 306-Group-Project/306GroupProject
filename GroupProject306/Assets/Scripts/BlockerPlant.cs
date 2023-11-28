using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerPlant : MonoBehaviour
{
   
    public float health = 100.0f;
    public float damage = 10.0f;
    public float damageTime;
    public float damageRate = 1.0f;

    public float decomposeDamage = 2.0f;
    public float decomposeRateSeconds = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decompose", decomposeRateSeconds, decomposeRateSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Renderer>().material.color = new Color(0.64f, health / 100, 0.03f);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (Time.time >= damageTime)
            {
                health -= damage;
                if (health <= 0)
                {
                    Destroy(this.gameObject);
                }

                damageTime = Time.time + damageRate;
            }
        }
    }

    private void decompose()
    {
        health -= decomposeDamage;

        if(health <= 0)
        {
            Destroy(this.gameObject);
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

	 public void ApplyHealthRestoreUpgrade(float healthToRestore)
    {
        health += healthToRestore;
        health = Mathf.Clamp(health, 0, 100.0f);
    }
}
