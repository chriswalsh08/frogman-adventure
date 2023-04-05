using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{

    // make it able to attach to a gameobject
    [SerializeField] private TextMeshProUGUI scoreText;

    // create singleton pattern for scoremanager
    public static ScoreManager Instance { get; private set; }
    public static int Score { get; private set; }
    public static string PreviousLevel { get; private set; }
    public static int PreviousLevelScore { get; private set; }

    private void Awake()
    {
        Instance = this;
        InitializeScores();
    }

    // increase score by integer amount
    public void IncreaseScore(int amount)
    {      
        Score += amount;
        scoreText.text = "Score: " + Score;
    }

    // save the player's score at the end of a level
    public void SaveLevelScore()
    {
        // set the current level name for ResetLevelScore();
        PreviousLevel = SceneManager.GetActiveScene().name;

        // save the current level score
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, Score);
    }

    // reset the score back to level start when player dies
    public void ResetLevelScore()
    {

        if (PreviousLevel == null)
        {
            Score = 0;
            PreviousLevelScore = 0;
        }
        else
        {
            PreviousLevelScore = PlayerPrefs.GetInt(PreviousLevel);
            Score = PreviousLevelScore;
        }

        scoreText.text = "Score: " + PreviousLevelScore;
    }

    // reset the entire game's score when the player reaches the end and clicks restart
    public void RestartGameScore()
    {
        Score = 0;
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, Score);
        PreviousLevelScore = 0;
        scoreText.text = "Score: " + Score;
    }

    public void InitializeScores()
    {
        if (!PlayerPrefs.HasKey("highscore") && !PlayerPrefs.HasKey("timeHighscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
            PlayerPrefs.SetFloat("timeHighscore", 0);
        }
    }

    // save player's highscores
    public void SaveHighscores()
    {
        if (Score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", Score);
        }
        else if (Timer.currentTime < PlayerPrefs.GetFloat("timeHighscore") || PlayerPrefs.GetFloat("timeHighscore") == 0)
        {
            PlayerPrefs.SetFloat("timeHighscore", Timer.currentTime);
        }
    }
}