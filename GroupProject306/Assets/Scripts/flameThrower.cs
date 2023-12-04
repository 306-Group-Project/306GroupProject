using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flameThrower : MonoBehaviour
{
    public GameObject flames;
    public Slider loading;

    public bool explosionEnabled = false;

    public float loadingTime = 2.0f;
    public int loadingRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        loading.value = 0;
        InvokeRepeating("setSlider", loadingTime, loadingTime);
    }

    // Update is called once per frame
    void Update()
    {
        //shoot();
    }

    public void shoot()
    {
        if (explosionEnabled)
        {
            GameObject cloud = Instantiate(flames, this.transform.position + new Vector3(0, -0.5f, 0), this.transform.rotation);

            Destroy(cloud, 1.0f);
            
            explosionEnabled = false;
            loading.value = 0;
        } 
        else if(GameManager.instance.getScore() >= 10){
            explosionEnabled=true;
            loading.value = 100;
            GameManager.instance.AddPoints(-10);
        }
    }

    public void setSlider()
    {
        if (loading.value < 100)
        {
            loading.value += loadingRate;
        }

        if(loading.value >= 100)
        {
            explosionEnabled = true;
        }
    }

}
