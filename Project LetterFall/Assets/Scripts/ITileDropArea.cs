using UnityEngine;

public interface ITileDropArea
{
    void OnTileDrop(LetterTile tile);

    void OnTileRemoved(LetterTile tile);
}
