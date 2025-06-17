using UnityEngine;

public class BinSlot : MonoBehaviour, ITileDropArea
{
    public void OnTileDrop(LetterTile tile) //what to do when a Letter Tile is dropped on the slot
    {
        Destroy(tile.gameObject);
    }

    public void OnTileRemoved(LetterTile tile) //what to do when a Letter Tile is removed from the slot
    {
        
        
    }
}
