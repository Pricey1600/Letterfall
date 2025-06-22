using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using System;
using NUnit.Framework;
using System.Text.RegularExpressions;

public class WordLookUp : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    public TMP_InputField userInput;
    //public TextMeshProUGUI output;

    private string[] words = { };

    //public PointsManager pointsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dictionaryTextFile = Resources.Load("wordsAlpha") as TextAsset;
        Debug.Log("Words File Name: " + dictionaryTextFile.name);
        //Debug.Log("NewLine Char: " + Environment.NewLine.ToCharArray()[0]);
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            words = dictionaryTextFile.text.Split(Environment.NewLine.ToCharArray());
        }
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            words = dictionaryTextFile.text.Split("\r\n");
        }

        Debug.Log("The number of available words: " + words.Length);
        Debug.Log("Words such as: " + words[30364]);
        Debug.Log("Type: " + words.GetType());
        Debug.Log(words[10]);

    }

    public bool checkWord(string userWord)
    {
        //Debug.Log("User Word: " + userInput.text);
        //Debug.Log(words.Length);
        //Debug.Log("Checking Word: "+userWord.ToLower());
        Debug.Log("User Word Type: " + userWord.GetType());
        if (checkDictionary(userWord.ToLower()))
        {
            //output.text = "Valid";
            //pointsManager.addPoints(1);
            return true;
        }
        else
        {
            //output.text = "INVALID";
            return false;
        }
        
    }

    private bool checkDictionary(string word)
    {
        if (Array.Exists(words, el => el == word))
        {
            Debug.Log("WORD FOUND");
            return true;
        }

        Debug.Log("WORD NOT FOUND");
        return false;

        // foreach (string str in words)
        // {
        //     if (str == word)
        //     {
        //         Debug.Log("Checking word: " + str);
        //         return true;
        //     }
        // }
        // Debug.Log("NO MATCHES FOUND");
        // return false;
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
