using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float maxHealth = 100.0f;

    [SerializeField] private float damageToPlayer = 20.0f;
    [SerializeField] private float damageRate = 0.7f;
    [SerializeField] private float damageTime;

    // Start is called before the first frame update
    void Awake()
    {
       
    }

    private void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (GameManager.instance.windMill)
        {
            transform.LookAt(GameManager.instance.windMill.transform.position);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            //Destroy(effect, 1.0f);
            Destroy(this.gameObject);

        }
    }
}


