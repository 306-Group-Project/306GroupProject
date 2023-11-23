using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameThrower : MonoBehaviour
{
    public GameObject flames;

    public float fireTime;
    public float fireRate = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //shoot();
    }

    public void shoot()
    {
        if (Time.time >= fireTime)
        {
            GameObject cloud = Instantiate(flames, this.transform.position + new Vector3(0, -0.5f, 0), this.transform.rotation);

            Destroy(cloud, 1.0f);
            fireTime = Time.time + fireRate;
        }
    }

}
