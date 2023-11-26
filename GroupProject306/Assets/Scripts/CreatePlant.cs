using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlant : MonoBehaviour
{
    public GameManager manager;

    public GameObject Prefab;
    public GameObject Planting;
    public float offset = 3.0f;
    public int cost = 0;

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
}
