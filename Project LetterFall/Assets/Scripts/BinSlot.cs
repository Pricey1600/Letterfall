using UnityEngine;

public class BinSlot : MonoBehaviour, ITileDropArea
{
    private PlayAudio playAudio;

    private void Awake() {
        playAudio = GetComponent<PlayAudio>();
    }
    public void OnTileDrop(LetterTile tile) //what to do when a Letter Tile is dropped on the slot
    {
        playAudio.playAudio();
        Destroy(tile.gameObject);
    }

    public void OnTileRemoved(LetterTile tile) //what to do when a Letter Tile is removed from the slot
    {
        
        
    }
}
