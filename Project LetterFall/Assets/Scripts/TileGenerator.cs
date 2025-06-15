using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tileSlot, letterTile;
    public GameObject newWordGrid;
    public float gridGapX, gridGapY;

    public float spawnDelay;

    private Vector2 gridCellSize;

    private List<GameObject> newWordTiles;

    private GameManager GM;

    void Start()
    {
        gridCellSize = tileSlot.GetComponent<SpriteRenderer>().bounds.size;
        Debug.Log(gridCellSize);
        Debug.Log(6 * gridCellSize.x);

        GM = GetComponent<GameManager>();

        //StartCoroutine(GenerateNewSlots(6));
    }
    public IEnumerator GenerateNewSlots(int numberOfSlots)
    {
        newWordTiles = new List<GameObject>();

        for (int i = 0; i < numberOfSlots; i++)
        {
            var newSlot = Instantiate(tileSlot, newWordGrid.transform.position, quaternion.identity);
            newWordTiles.Add(newSlot);
            newSlot.transform.parent = newWordGrid.transform;

            yield return new WaitForSeconds(spawnDelay);
        }

        sendNewTiles();
    }

    public void sendNewTiles()
    {
        //send the list of new word tiles to another manager
        GM.newWordSlots = newWordTiles;
    }

    
}
