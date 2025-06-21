using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    //public bool tutorialEnabled;
    public int tutorialStage = -1;
    public List<string> tutorialString = new List<string>();
    public List<Vector2> tutorialPos = new List<Vector2>();
    public RectTransform textBoxParent;
    private TextMeshProUGUI tutorialText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialText = textBoxParent.GetComponentInChildren<TextMeshProUGUI>();
        if (PlayerPrefs.GetInt("tutorialEnabled") != 0) {
            return;
        }
    }

    public void progressTutorial()
    {
        tutorialStage += 1;

        if (PlayerPrefs.GetInt("tutorialEnabled") != 0 || tutorialStage > (tutorialString.Count - 1))
        {
            if (tutorialStage > (tutorialString.Count - 1))
            {
                PlayerPrefs.SetInt("tutorialEnabled", 1);
            }
            textBoxParent.gameObject.SetActive(false);
            return;
        }
        else if (textBoxParent.gameObject.activeSelf == false)
        {
            textBoxParent.gameObject.SetActive(true);
        }

        textBoxParent.anchoredPosition = tutorialPos[tutorialStage];
        tutorialText.text = tutorialString[tutorialStage];
    }
}
