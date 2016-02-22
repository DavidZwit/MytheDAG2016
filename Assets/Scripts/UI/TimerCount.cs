using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private float timerCounter;

    void Update()
    {
        //Setting the minutes, seconds and miliseconds for the countdown
        timerCounter -= Time.deltaTime;

        float min = Mathf.Floor(timerCounter / 60);
        float sec = timerCounter % 60;
        float mil = (timerCounter * 100) % 100;

        timerText.text = string.Format("Time left: {0:0} : {1:00} : {2:00}", min, sec, mil);
    }
}