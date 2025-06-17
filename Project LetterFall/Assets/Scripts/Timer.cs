using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public delegate void TimerAction();
    public static event TimerAction OnTimeOut;
    public float turnTime = 60f; //time per turn in seconds
    [SerializeField] private float turnTimeRemaining = 0f; //the timer itself

    public Slider timerSlider;

    private bool timerRunning = false;

    private bool pauseTimer;

    void Start()
    {
        timerSlider.maxValue = turnTime;
    }
    public void resetTimer()
    {
        turnTimeRemaining = turnTime;
        timerSlider.maxValue = turnTime;
    }

    public void toggleTimer()
    {
        pauseTimer = !pauseTimer;
    }

    void Update()
    {
        timerSlider.value = turnTimeRemaining;
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
