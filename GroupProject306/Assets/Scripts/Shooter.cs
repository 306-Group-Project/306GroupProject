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
    // variable for sound effect for shooting projectile
    private AudioSource projectileSound;

    // Start is called before the first frame update
    void Start()
    {
        // this calls and sets up audiosource component
        projectileSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Time.time >= fireTime && curTarget)
        {
            //GameObject shotProj = Instantiate(projectile, transform.position, Quaternion.identity);
            //Debug.DrawLine(transform.position, transform.position + transform.forward*5f,Color.red,3f);
            //shotProj.transform.forward = transform.forward;
            //if (curTarget)
            //{
              //  shotProj.transform.LookAt(curTarget);
            //}
            
            GameObject proj = Instantiate(projectile, transform.position, transform.rotation );
            projectileSound.Play();
            proj.transform.LookAt(curTarget);

            
            proj.GetComponent<Projectile>().setTarget(curTarget);
            

            fireTime = Time.time + fireRate;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy" && !curTarget)
        {
            transform.LookAt(other.transform.position);
            curTarget = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!curTarget == other.transform) { 
        curTarget = null;
        }
    }

}
