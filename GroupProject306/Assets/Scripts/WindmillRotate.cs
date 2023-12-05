using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotate : MonoBehaviour
{
    public GameObject fan;
    public float rotateSpeed = 40.0f;
    [SerializeField] float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = this.GetComponentInParent<WindMill>().getHp();
        transform.Rotate(Vector3.forward * (rotateSpeed * (health-15)/100) * Time.deltaTime);
    }
}
