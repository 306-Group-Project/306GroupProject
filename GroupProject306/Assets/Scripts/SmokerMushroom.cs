using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokerMushroom : MonoBehaviour
{
    public GameObject smoke;
    public float health = 100.0f;
    public float fireTime;
    public float fireRate = 1.0f;
    public float damage = 10.0f;
    // variable for sound effect for smoking mushroom
    private AudioSource smokeSound;
    // Start is called before the first frame update
    void Start()
    {
        // this calls and sets up audiosource component
        smokeSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        if (Time.time >= fireTime)
        {
            GameObject cloud = Instantiate(smoke, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);
            smokeSound.Play();
            Destroy(cloud, 0.5f);
            fireTime = Time.time + fireRate;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Shoot();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void IncreaseDamage(float damageIncrease)
    {
        damage += damageIncrease;
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
