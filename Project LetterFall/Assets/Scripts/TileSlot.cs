using Unity.VisualScripting;
using UnityEngine;

public class TileSlot : MonoBehaviour, ITileDropArea
{
    private char letterValue;
    public bool holdingTile = false;
    public GameObject currentTile;
    public void OnTileDrop(LetterTile tile) //what to do when a Letter Tile is dropped on the slot
    {
        if (holdingTile && currentTile != null) //if already holding a tile
        {
            currentTile.TryGetComponent(out IDrag letterTile); 
            letterTile.onSwapped(tile.startDragPos); //swap positions with new tile
        }

        currentTile = tile.gameObject;
        tile.transform.position = transform.position;
        Debug.Log("Card dropped here");
        letterValue = tile.GetComponent<LetterTile>().letter;
        Debug.Log("Letter Value set to " + letterValue);
        holdingTile = true;
    }

    public void OnTileRemoved(LetterTile tile)
    {
        holdingTile = false;
        Debug.Log("Tile removed");
    }
}
