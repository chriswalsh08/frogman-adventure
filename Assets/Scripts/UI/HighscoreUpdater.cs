using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HighscoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscore;
    [SerializeField] private TextMeshProUGUI timeHighscore;
    private float floatTime;

    // Start is called before the first frame update
    void Awake()
    {
        ScoreManager.Instance.SaveHighscores();

        floatTime = PlayerPrefs.GetFloat("timeHighscore");

        // update the highscores on the end menu
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        timeHighscore.text = "Fastest Time: " + TimeSpan.FromSeconds(floatTime).ToString(@"mm\:ss");
    }
}
