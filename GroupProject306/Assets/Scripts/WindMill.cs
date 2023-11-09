using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    [SerializeField] public float health = 100.0f;
    public GameManager manager;
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
           // Destroy(other.gameObject);
        }
    }

    public void TakeDamge(float damage)
    {
        health -= damage;
        healthbar.GetComponent<WindMillHealth>().SetHealth(health);

        if (health < 0)
        {
            Destroy(this.gameObject);
            manager.EndGame();
            
        }
    }
    // returns current hp
    public float getHp()
    {
        return health;
    }
}
