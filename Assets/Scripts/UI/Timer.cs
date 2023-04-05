using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    // timer stuff
    public static bool timerActive = true;
    public static float currentTime = 0f;

    [SerializeField] private TextMeshProUGUI timeText;

    void Start()
    {
        currentTime = 0;
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        timeText.text = "Time: " + time.ToString(@"mm\:ss");
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
