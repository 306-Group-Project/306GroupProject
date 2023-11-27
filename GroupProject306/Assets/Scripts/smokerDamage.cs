using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokerDamage : MonoBehaviour
{
    public float damageTime;
    public float damageRate = 1.0f;
    public float damage = 10.0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (Time.time >= damageTime)
            {
                this.GetComponentInParent<SmokerMushroom>().TakeDamage(damageRate);
                damageTime = Time.time + damageRate;
            }
        }
    }
}
