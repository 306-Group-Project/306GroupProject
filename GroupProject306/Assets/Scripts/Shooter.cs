using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float fireTime;
    public float fireRate = 1.0f;
    public Transform curTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Time.time >= fireTime)
        {
            //GameObject shotProj = Instantiate(projectile, transform.position, Quaternion.identity);
            //Debug.DrawLine(transform.position, transform.position + transform.forward*5f,Color.red,3f);
            //shotProj.transform.forward = transform.forward;
            //if (curTarget)
            //{
              //  shotProj.transform.LookAt(curTarget);
            //}
            
            GameObject proj = Instantiate(projectile, transform.position, transform.rotation );
            proj.transform.LookAt( curTarget );
            fireTime = Time.time + fireRate;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            transform.LookAt(other.transform.position);
            curTarget = other.transform;
        }
    }

}
