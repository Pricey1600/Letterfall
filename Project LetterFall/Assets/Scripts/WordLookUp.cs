using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.IO;

public class WordLookUp : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    public TMP_InputField userInput;
    public TextMeshProUGUI output;

    private string[] words;

    //public PointsManager pointsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string path = AssetDatabase.GetAssetPath(dictionaryTextFile);
        words = File.ReadAllLines(path);

        Debug.Log("The number of available words: " + words.Length);
        Debug.Log("Words such as: "+words[30364]);

    }

    public bool checkWord(string userWord)
    {
        //Debug.Log("User Word: " + userInput.text);
        //Debug.Log(words.Length);
        //Debug.Log("Checking Word: "+userWord.ToLower());
        if (checkDictionary(userWord.ToLower()))
        {
            output.text = "Valid";
            //pointsManager.addPoints(1);
            return true;
        }
        else
        {
            output.text = "INVALID";
            return false;
        }
        
    }

    private bool checkDictionary(string word)
    {
        foreach (string str in words)
        {
            if (str == word)
            {
                Debug.Log("Checking word: " + str);
                return true;
            }
        }
        Debug.Log("NO MATCHES FOUND");
        return false;
        //Debug.Log("words array size: "+words.);
        // Debug.Log(Array.Exists(words, el => el == word) +" "+ word);
        // if (Array.Exists(words, el => el == word))
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }


    }

}
