using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public delegate void TimerAction();
    public static event TimerAction OnTimeOut;
    public float turnTime = 60f; //time per turn in seconds
    [SerializeField] private float turnTimeRemaining = 0f; //the timer itself

    public Slider timerSlider;
    public TextMeshPro timerText;

    private bool timerRunning = false;

    private bool pauseTimer;

    private string timerTextStart = "0:";

    void Start()
    {
        //timerSlider.maxValue = turnTime;
    }
    public void resetTimer()
    {
        turnTimeRemaining = turnTime;
        //timerSlider.maxValue = turnTime;
        timerText.text = timerTextStart + turnTime.ToString();
    }

    public void toggleTimer()
    {
        pauseTimer = !pauseTimer;
    }

    void Update()
    {
        //timerSlider.value = turnTimeRemaining;
        timerText.text = timerTextStart + Mathf.FloorToInt(turnTimeRemaining).ToString();
        if (pauseTimer)
        {
            return;
        }
        if (turnTimeRemaining > 0f)
        {
            turnTimeRemaining -= Time.deltaTime;
            timerRunning = true;
        }

        if (turnTimeRemaining <= 0f && timerRunning)
        {
            timerRunning = false;
            OnTimeOut();
        }
    }
}
