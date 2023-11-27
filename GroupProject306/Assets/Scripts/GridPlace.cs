using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlace : MonoBehaviour
{
    public GameObject hexPrefab;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float hexRadius = 1;
    public float hexHeight = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
       createGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createGrid()
    {
        float hexWidth = Mathf.Sqrt(3) * hexRadius;
        float hexHeight = 2 * hexRadius;
        float verticalSpacing = hexHeight * 0.55f;
        float horizontalSpacing = hexWidth + 0.1f;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float xPos = x * horizontalSpacing;
                float yPos = y * verticalSpacing / 2;

                if(y%2 == 1)
                {
                    xPos += horizontalSpacing / 2;
                    //yPos += verticalSpacing / 2;
                }

                GameObject hex = Instantiate(hexPrefab, new Vector3(xPos, 0, yPos),Quaternion.Euler(-90f,0,0) );
                hex.transform.parent = this.transform;
            }
        }
    }
}
