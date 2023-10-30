using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float damage = 50.0f;
    public Transform curTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        if (curTarget != null)
        {
            transform.LookAt(curTarget.transform.position);
        }
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    public void setTarget(Transform other)
    {
        curTarget = other;
    }

}
