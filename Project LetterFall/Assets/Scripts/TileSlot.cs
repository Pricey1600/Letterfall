using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;

public class TileSlot : MonoBehaviour, ITileDropArea
{
    public char letterValue;
    public bool holdingTile = false, reusableTiles = false;
    public GameObject currentTile;

    public GameObject tilePrefab;
    
    public List<Sprite> slotSprites = new List<Sprite>();
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (slotSprites.Count > 0)
        {
            Sprite tileBG = slotSprites[UnityEngine.Random.Range(0, slotSprites.Count)];
            spriteRenderer.sprite = tileBG;
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            
        }
    }
    public void OnTileDrop(LetterTile tile) //what to do when a Letter Tile is dropped on the slot
    {
        if (currentTile != null)
        {
            if (tile.gameObject == currentTile.gameObject)
            {
                return;
            }
            if (holdingTile && currentTile != null && !reusableTiles) //if already holding a tile
            {
                currentTile.TryGetComponent(out IDrag letterTile);
                letterTile.onSwapped(tile.startDragPos); //swap positions with new tile
            }
        }


        if (!reusableTiles)
        {
            currentTile = tile.gameObject;
            tile.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
            Debug.Log("Card dropped here");
            letterValue = tile.GetComponent<LetterTile>().letter;
            Debug.Log("Letter Value set to " + letterValue);
            holdingTile = true;
        }
        else
        {
            Destroy(tile.gameObject);
            Debug.Log("INCOMING TILE DESTROYED");
            if (holdingTile) //if the dropped tile does not have the same value as the reusable tiles
            {
                // Destroy(tile.gameObject);
                // Debug.Log("INCOMING TILE DESTROYED");
            }
        }

    }

    public void OnTileRemoved(LetterTile tile) //what to do when a Letter Tile is removed from the slot
    {
        if (!reusableTiles)
        {
            holdingTile = false;
            Debug.Log("Tile removed");
        }
        else
        {
            tile.transform.parent = null;
            spawnTile();
        }

    }
    public void spawnTile()
    {
        holdingTile = false;
        //spawn a new tile
        currentTile = null;
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        GameObject newTile = Instantiate(tilePrefab, spawnPos, quaternion.identity);
        currentTile = newTile;
        newTile.transform.parent = this.transform;
        LetterTile newTileScript = newTile.GetComponent<LetterTile>();
        newTileScript.letter = letterValue;
        newTileScript.updateValues();
        newTileScript.spawnAdjust(this);
    }
}
