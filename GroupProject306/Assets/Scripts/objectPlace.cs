using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPlace : MonoBehaviour
{

    public GameObject tree;
    public GameObject rock;

    public int gridWidth = 10;
    public int gridHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        placeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void placeObjects()
    {
 
        for (int x = 0; x < 20; x++)
        {
            float xPos = Random.Range(-4f, 3f);
            float yPos = Random.Range(-4f, 3f);

            GameObject obj = Instantiate(tree, new Vector3(xPos, 0, yPos), Quaternion.Euler(-90, 0, 0));
            obj.transform.parent = this.transform;
        }

        for (int x = 0; x < 15; x++)
        {
            float xPos = Random.Range(-5f, 5f);
            float yPos = Random.Range(-5f, 5f);

            GameObject obj = Instantiate(rock, new Vector3(xPos, 0, yPos), Quaternion.Euler(-90, 0, 0));
            obj.transform.parent = this.transform;
        }


    }

}
