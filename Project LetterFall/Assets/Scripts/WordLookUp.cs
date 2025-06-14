using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordLookUp : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    public TMP_InputField userInput;
    public TextMeshProUGUI output;

    private string[] words;
    private string dictString;

    public PointsManager pointsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dictString = dictionaryTextFile.text;

        words = dictString.Split('\n');

        //Debug.Log(words[1]);

    }

    public void checkWord()
    {
        Debug.Log("User Word: " + userInput.text);
        //Debug.Log(words.Length);
        if (checkDictionary(userInput.text.ToLower()))
        {
            output.text = "Valid";
            pointsManager.addPoints(1);
        }
        else
        {
            output.text = "INVALID";
        }
        
    }

    private bool checkDictionary(string userWord)
    {
        foreach (string str in words)
        {
            if (str.Contains(userWord))
            {
                return true;
            }
        }
        return false;
        
    }

}
