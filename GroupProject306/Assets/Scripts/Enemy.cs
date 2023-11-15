using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 0.5f;
	[SerializeField] public float originalMoveSpeed 0.5f;
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float maxHealth = 100.0f;

    [SerializeField] private float damageRate = 0.7f;
    [SerializeField] private float damage = 10.0f;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Windmill") {

            other.GetComponent<WindMill>().TakeDamge(damage);
        }
    }
}


