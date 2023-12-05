using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlant : MonoBehaviour
{
    public GameManager manager;
    public GameObject text;
	public AudioScript audioScript;
    
    public GameObject Prefab;
    public GameObject Planting;
    public float offset = 3.0f;

    public Vector3 worldPosition;

    public Plane plane = new Plane(Vector3.up, 0);

    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        { 
            worldPosition = ray.GetPoint(distance);
            worldPosition.y += 0.08f;
        }

        if (Planting) 
        { 
            Planting.transform.position = worldPosition;
        }
        make();
    }

    public void make()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        if (Input.GetMouseButtonDown(0) && Planting)
        {
            Planting = null;
        }
    }

    public void SetFlower()
    {
        Planting = Instantiate(Prefab);
    }
    
    public void grassButton()
    {
        int cost = 4;
        if (manager.getScore() >= cost)
        {
            manager.AddPoints(-cost);
            SetFlower();
			audioScript.playConfirmPlant();
        }
        else
        {
            audioScript.playInsufficentFunds();
        }
    }
    
    public void hyacinthButton()
    {
        int cost = 1;
        if (manager.getScore() >= cost)
        {
            manager.AddPoints(-cost);
            SetFlower();
			audioScript.playConfirmPlant();
        }
        else
        {
            audioScript.playInsufficentFunds();
        }
    }
    
    public void sunflowerButton()
    {
        int cost = 5;
        if (manager.getScore() >= cost)
        {
            manager.AddPoints(-cost);
            SetFlower();
			audioScript.playConfirmPlant();
        }
        else
        {
            audioScript.playInsufficentFunds();
        }
    }
    
    public void daffodilButton()
    {
        int cost = 4;
        if (manager.getScore() >= cost)
        {
            manager.AddPoints(-cost);
            SetFlower();
			audioScript.playConfirmPlant();
        }
        else
        {
            audioScript.playInsufficentFunds();
        }
    }
    
    public void mushButton()
    {
        int cost = 2;
        if (manager.getScore() >= cost)
        {
            manager.AddPoints(-cost);
            SetFlower();
			audioScript.playConfirmPlant();
        }
        else
        {
            audioScript.playInsufficentFunds();
        }
    }

}
