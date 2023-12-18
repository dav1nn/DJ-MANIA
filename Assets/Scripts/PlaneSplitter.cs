using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSplitter : MonoBehaviour
{
    public GameObject squarePrefab; 
    public int gridSize = 10; 
    public float squareSize = 1.0f; 

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
   Vector3 startPosition = transform.position; 

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                
                Vector3 position = startPosition + new Vector3(x * squareSize, 0, z * squareSize);
                GameObject newSquare = Instantiate(squarePrefab, position, Quaternion.identity);
                newSquare.transform.SetParent(this.transform);
                
            }
        }
    }
}
