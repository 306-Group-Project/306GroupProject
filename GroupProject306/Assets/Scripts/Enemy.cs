using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameManager gameManager; 
    
    [SerializeField] public float moveSpeed = 0.5f;
	[SerializeField] public float originalMoveSpeed = 0.5f;
    [SerializeField] protected float health = 100.0f;
    [SerializeField] protected float maxHealth = 100.0f;

    [SerializeField] private float damageRate = 0.7f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float damageTime = 0.0f ;
    
    private Light mylight;
    
    public GameObject Coin; 

    public bool stuck = false;
    
    public static int counter = 0; // coin tracker for text screens
    
    public float screenDuration = 2f; // Duration of the screen in seconds

    
    void Start()
    {
        mylight = GetComponent<Light>();
        gameManager = GameObject.FindObjectOfType<GameManager>(); // Find the GameManager instance

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
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
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
        counter++;
        
        Vector3 position = transform.position; // enemy position

        GameObject coin = Instantiate(Coin, position + new Vector3(0f, 0.2f, 0f), Quaternion.identity); // coin drop 
        coin.SetActive(true);

        if (counter == 1) {
            gameManager.coinInstructionScreen.SetActive(true);
            StartCoroutine(DeactivateScreenAfterDelay());
            
        }
            else if (counter != 1) {
            gameManager.coinInstructionScreen.SetActive(false);
        }

            Destroy(coin, 5f);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Windmill") {
            other.GetComponent<WindMill>().TakeDamge(damage);
            Destroy(this.gameObject);
            this.GetComponentInParent<LevelSystem>().DecreaseLivingEnemies();
        } else if(other.gameObject.tag == "object")
        {
            Debug.Log("object");
            transform.position -= transform.forward * moveSpeed * 10 * Time.deltaTime;
            transform.position += transform.right * moveSpeed * 10 * Time.deltaTime;
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
    
    IEnumerator DeactivateScreenAfterDelay()
    {
        yield return new WaitForSeconds(screenDuration);
        gameManager.coinInstructionScreen.SetActive(false);
    }
    
}


