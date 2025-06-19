using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimatedObject : MonoBehaviour
{
    public delegate void AnimationAction();
    public static event AnimationAction Ready;

    private Animator AC;

    private void Awake() {
       AC = GetComponent<Animator>();
    }

    void OnEnable()
    {
        //GameManager.turnOver += animationStart;
        //GameManager.turnStart += animationEnd;
    }
    void OnDisable()
    {
        //GameManager.turnOver -= animationStart;
        //GameManager.turnStart -= animationEnd;
    }

    private void animationStart(){
        AC.SetBool("changing_turn", true);
    }
    private void animationEnd(){
        AC.SetBool("changing_turn", false);
    }

    public void ready(){
        Ready();
    }
}
