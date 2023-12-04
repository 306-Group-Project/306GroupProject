using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 0.5f;
	[SerializeField] public float originalMoveSpeed = 0.5f;
    [SerializeField] protected float health = 100.0f;
    [SerializeField] protected float maxHealth = 100.0f;

    [SerializeField] private float damageRate = 0.7f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float damageTime = 0.0f ;
    private Light mylight;
    
    public GameObject Coin; 
    
    void Start()
    {
        mylight = GetComponent<Light>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        if (health <= maxHealth / 2.0f)
        {
            mylight.enabled = true;
        }

    }

    private void Movement()
    {
        if (GameManager.instance.windMill)
        {
            transform.LookAt(GameManager.instance.windMill.transform.position);
            transform.position  += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GameManager.instance.increaseEnemyKill();

            //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            //Destroy(effect, 1.0f);
            this.GetComponentInParent<LevelSystem>().DecreaseLivingEnemies();
            Destroy(this.gameObject);
            
            DropCoin();
        }
    }

    void DropCoin() {
        Vector3 position = transform.position; // enemy position

        GameObject coin = Instantiate(Coin, position + new Vector3(0f, 0.2f, 0f), Quaternion.identity); // coin drop 
        coin.SetActive(true);
        //Destroy(coin,10f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Windmill") {
            other.GetComponent<WindMill>().TakeDamge(damage);
            Destroy(this.gameObject);
            this.GetComponentInParent<LevelSystem>().DecreaseLivingEnemies();
        }
    }

    public void slowMoveSpeed(float percentSlowDown)
    {
        moveSpeed = moveSpeed * percentSlowDown;
    }

    public void resetSpeed()
    {
        moveSpeed = originalMoveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "object")
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }
}


