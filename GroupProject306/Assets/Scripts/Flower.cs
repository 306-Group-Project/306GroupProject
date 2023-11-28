using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float health = 100.0f;
    public float damageTime;

    public float decomposeDamage = 2.0f;
    public float decomposeRateSeconds = 5.0f;

	private Shooter shooter;

    private void Start()
    {
        InvokeRepeating("decompose", decomposeRateSeconds, decomposeRateSeconds);
		shooter = GetComponent<Shooter>();
    }


    private void Update()
    {
        this.GetComponent<Renderer>().material.color = new Color(0.64f, health / 100, 0.03f);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            transform.LookAt(other.transform.position);
        }
    }

    private void decompose()
    {
        health -= decomposeDamage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
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

	public void ApplyFireRateUpgrade(float multiplier, float duration)
    {
        if (shooter != null)
        {
            shooter.SetFireRate(shooter.baseFireRate * multiplier);
            StartCoroutine(ResetFireRateAfterDelay(multiplier, duration));
        }
    }

    private IEnumerator ResetFireRateAfterDelay(float originalMultiplier, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (shooter != null)
        {
            shooter.SetFireRate(shooter.baseFireRate);
        }
    }
}
