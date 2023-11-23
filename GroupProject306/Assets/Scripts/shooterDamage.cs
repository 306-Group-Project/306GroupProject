using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterDamage : MonoBehaviour
{
    public float damageTime;
    public float damageRate = 1.0f;
    public float damage = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (Time.time >= damageTime)
            {
                this.GetComponentInParent<SmokerMushroom>().TakeDamage(damage);
                damageTime = Time.time + damageRate;
            }
        }
    }
}
