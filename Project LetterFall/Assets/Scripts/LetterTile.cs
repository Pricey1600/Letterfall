using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class LetterTile : MonoBehaviour, IDrag
{

    private Collider2D col;
    private LayerMask dropMask;

    public Vector2 startDragPos;

    public char letter;
    public TMP_Text letterText;
    public int pointsValue;

    private GameObject currentSlot;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        dropMask = ~LayerMask.GetMask("Draggable");
        letterText.text = letter.ToString();
        startDragPos = transform.position;
    }

    public void onEndDrag() //what the tile wants to do when stopped being dragged
    {

        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position, dropMask);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out ITileDropArea tileSlot))
        {
            if (currentSlot != null)
            {
                var currentDropArea = currentSlot.TryGetComponent(out ITileDropArea currentTileSlot);
                currentTileSlot.OnTileRemoved(this);
            }
            currentSlot = hitCollider.gameObject;
            tileSlot.OnTileDrop(this);
        }
        else
        {
            transform.position = startDragPos;
        }

    }

    public void onStartDrag() //what the tile wants to do when being dragged
    {
        col.enabled = false;
        startDragPos = transform.position;
    }

    public void onSwapped(Vector2 swapPos)
    {
        currentSlot = null;

        transform.position = swapPos;

        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position, dropMask);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out ITileDropArea tileSlot))
        {
            currentSlot = hitCollider.gameObject;
            tileSlot.OnTileDrop(this);
        }
        else
        {
            transform.position = startDragPos;
        }
        
    }
    
}
