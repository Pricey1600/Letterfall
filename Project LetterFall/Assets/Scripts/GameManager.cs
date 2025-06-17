using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private TileGenerator tileGenerator;
    private WordLookUp wordLookUp;
    private PointsManager pointsManager;
    private Timer timer;
    public List<GameObject> newWordSlots = new List<GameObject>();
    public List<GameObject> oldWordSlots = new List<GameObject>();
    public GameObject oldWordGrid;
    public float wordMoveDelay;
    private List<GameObject> letterTiles = new List<GameObject>();
    private string submittedWord;
    public List<string> usedWords = new List<string>();

    void Awake()
    {
        tileGenerator = GetComponent<TileGenerator>();
        wordLookUp = GetComponent<WordLookUp>();
        pointsManager = GetComponent<PointsManager>();
        timer = GetComponent<Timer>();
    }
    void Start()
    {
        StartCoroutine(tileGenerator.GenerateNewSlots(20));
        StartCoroutine(tileGenerator.GenerateStartingSlots());
        //timer.resetTimer();
    }

    void OnEnable()
    {
        Timer.OnTimeOut += gameOver;
    }
    void OnDisable()
    {
        Timer.OnTimeOut -= gameOver;
    }

    public void wordCheck()
    {
        foreach (GameObject slot in newWordSlots)
        {
            TileSlot slotScript = slot.GetComponent<TileSlot>();
            if (slotScript.holdingTile)
            {
                submittedWord += slotScript.letterValue.ToString();
            }
        }
        Debug.Log("Submitted Word: " + submittedWord);

        if (usedWords.Contains(submittedWord))
        {
            Debug.Log("Word Already Used: " + submittedWord);
        }
        else if (wordLookUp.checkWord(submittedWord))
        {
            timer.toggleTimer();
            pointsManager.addPoints(submittedWord.Length);
            usedWords.Add(submittedWord);
            if (submittedWord.Length > 1)
            {
                StartCoroutine(moveWord(submittedWord.Length)); //move word to be used in letter bank
                timer.resetTimer();
                timer.toggleTimer();
            }
            else
            {
                Debug.Log("NO MORE WORDS CAN BE MADE");
            }
            
        }

        submittedWord = ""; //reset string
    }

    IEnumerator moveWord(int wordLength)
    {
        foreach (GameObject slot in oldWordSlots)
        {
            if (slot != null)
            {
                slot.GetComponent<SpriteRenderer>().enabled = false;
                foreach (Transform child in slot.transform)
                {
                    letterTiles.Remove(child.gameObject);
                    Destroy(child.gameObject);
                }
            }
            yield return new WaitForSeconds(tileGenerator.spawnDelay);
            
        }
        foreach (GameObject slot in newWordSlots)
        {
            TileSlot slotScript = slot.GetComponent<TileSlot>();
            if (slotScript != null)
            {
                if (slot.GetComponent<TileSlot>().holdingTile)
                {
                    letterTiles.Add(slotScript.currentTile);
                    slotScript.currentTile.transform.parent = slot.transform;
                    Collider2D tileCollider = slotScript.currentTile.GetComponent<Collider2D>();
                    tileCollider.enabled = false;
                    slotScript.currentTile.transform.localPosition = new Vector3(0, 0, -0.1f);
                    slot.transform.parent = oldWordGrid.transform;
                    slotScript.reusableTiles = true;
                }
                else
                {
                    Destroy(slot);
                }
                yield return new WaitForSeconds(wordMoveDelay);
            }
        }

        foreach (GameObject slot in oldWordSlots)
        {
            if (slot != null)
            {
                if (slot.GetComponent<TileSlot>() != null)
                {
                    letterTiles.Remove(slot.GetComponent<TileSlot>().currentTile);
                }
            }
            Destroy(slot);
        }
        oldWordSlots.Clear();

        foreach (GameObject slot in newWordSlots)
        {
            oldWordSlots.Add(slot);
        }
        newWordSlots.Clear();
        StartCoroutine(tileGenerator.GenerateNewSlots(wordLength));
        toggleTiles(true);
    }

    void toggleTiles(bool state)
    {
        foreach (GameObject tile in letterTiles)
        {
            if (tile != null)
            {
                tile.GetComponent<Collider2D>().enabled = true;
            }
            
        }
    }

    void gameOver()
    {
        Debug.Log("TIME HAS RUN OUT");
    }
}
