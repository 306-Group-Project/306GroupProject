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

    // moved destroy to enemy script, to ensure damage is counted to windmill, then enemy is destroyed

    public void TakeDamge(float damage)
    {
        health -= damage;
        healthbar.GetComponent<WindMillHealth>().SetHealth(health);  
    }
    // returns current hp
    public float getHp()
    {
        return health;
    }
}
