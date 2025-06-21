using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class AnimatedObject : MonoBehaviour
{
    private Animator AC;
    private GameManager GM;
    

    public bool movingTiles = false;

    private void Awake()
    {
        AC = GetComponent<Animator>();
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void moveTiles()
    {
        if (!movingTiles)
        {
            movingTiles = true;
            GM.invokeMove();
            AC.SetBool("turn_change", false);
        }
        else
        {
            movingTiles = false;
        }
    }

    

    
    
}
