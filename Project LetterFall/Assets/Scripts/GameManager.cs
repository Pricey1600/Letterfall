using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private TileGenerator tileGenerator;
    private WordLookUp wordLookUp;
    private PointsManager pointsManager;
    public List<GameObject> newWordSlots = new List<GameObject>();
    private string submittedWord;

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

        if (wordLookUp.checkWord(submittedWord))
        {
            pointsManager.addPoints(submittedWord.Length);
        }

        submittedWord = ""; //reset string
    }

    void Awake()
    {
        tileGenerator = GetComponent<TileGenerator>();
        wordLookUp = GetComponent<WordLookUp>();
        pointsManager = GetComponent<PointsManager>();
    }
    void Start()
    {
        StartCoroutine(tileGenerator.GenerateNewSlots(6));
    }
}
