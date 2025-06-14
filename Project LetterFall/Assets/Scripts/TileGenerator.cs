using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tileSlot, letterTile;
    public GameObject newWordGrid;
    public float gridGap = 2;

    private Vector2 gridCellSize;

    private List<GameObject> newWordTiles;

    void Start()
    {
        gridCellSize = tileSlot.GetComponent<SpriteRenderer>().bounds.size;
        Debug.Log(gridCellSize);
        Debug.Log(6 * gridCellSize.x);

        GenerateNewSlots(6);
    }
    public void GenerateNewSlots(int numberOfSlots)
    {
        newWordTiles = new List<GameObject>();

        for (int i = 0; i < numberOfSlots; i++)
        {
            var newSlot = Instantiate(tileSlot, newWordGrid.transform.position, quaternion.identity);
            newWordTiles.Add(newSlot);
            newSlot.transform.parent = newWordGrid.transform;
        }
    }

    
}
