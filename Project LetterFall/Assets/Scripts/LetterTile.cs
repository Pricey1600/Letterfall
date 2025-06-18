using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterTile : MonoBehaviour, IDrag
{

    private Collider2D col;
    private LayerMask dropMask;

    public Vector3 startDragPos;

    public char letter;
    public TMP_Text letterText;
    public int pointsValue; //not currently used

    private GameObject currentSlot;

    public List<Sprite> tileSprites = new List<Sprite>();
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        dropMask = ~LayerMask.GetMask("Draggable");
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (tileSprites.Count > 0)
        {
            Sprite tileBG = tileSprites[Random.Range(0, tileSprites.Count)];
            spriteRenderer.sprite = tileBG;
            if (Random.Range(0, 2) == 1)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            
        }
    }
    void Start()
    {
        
        updateValues();
        
    }

    public void updateValues()
    {
        letterText.text = letter.ToString();
        startDragPos = transform.position;
    }

    public void onEndDrag() //what the tile wants to do when stopped being dragged
    {
        if (transform.position.z <= Camera.main.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startDragPos.z);
        }

        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position, dropMask);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out ITileDropArea tileSlot) && hitCollider.gameObject != currentSlot)
        {
            if (currentSlot != null)
            {
                currentSlot.TryGetComponent(out ITileDropArea currentTileSlot);
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

    public void spawnAdjust(TileSlot spawnSlot)
    {
        currentSlot = spawnSlot.gameObject;
        spawnSlot.OnTileDrop(this);
    }
    
}
