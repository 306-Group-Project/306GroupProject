using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEnemy : Enemy
{
    //[SerializeField] public float moveSpeed = 0.5f;
	//[SerializeField] public float originalMoveSpeed = 0.5f;
    private float bhealth = 100.0f;
    //[SerializeField] private float maxHealth = 100.0f;

    // [SerializeField] private float damageRate = 0.7f;
    private float bdamage = 10.0f;
    //[SerializeField] private float damageTime = 0.0f ;
    
    // public GameObject Coin;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.7f, transform.position.z); 
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
            Vector3 targetPosition = new Vector3(GameManager.instance.windMill.transform.position.x, this.transform.position.y, GameManager.instance.windMill.transform.position.z);
            transform.LookAt(targetPosition);
            transform.position  += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        bhealth -= damage;

        if(bhealth <= 0)
        {
            //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            //Destroy(effect, 1.0f);
            this.GetComponentInParent<LevelSystem>().DecreaseLivingEnemies();
            Destroy(this.gameObject);
            
            DropCoin();
        }
    }

    void DropCoin() {
        Vector3 position = transform.position; // enemy position

        GameObject coin = Instantiate(Coin, position, Quaternion.identity); // coin drop 
        coin.SetActive(true);
        Destroy(coin,10f); 
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Windmill") {
            other.GetComponent<WindMill>().TakeDamge(bdamage);
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
}


