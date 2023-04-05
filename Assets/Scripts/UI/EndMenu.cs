using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "EndMenu")
        {
            Destroy(GameObject.Find("BG Music"));
            Destroy(GameObject.Find("ScoreUI"));
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        // reset score and lives
        SceneManager.LoadScene(0);
        ScoreManager.Instance.RestartGameScore();
        Lives.health = 3;
        Lives.gameOver = false;
        Timer.currentTime = 0f;
        Timer.timerActive = false;

        // get rid of other canvases and restart time
        Time.timeScale = 1f;
        Destroy(GameObject.Find("BG Music"));
        Destroy(GameObject.Find("ScoreUI"));
    }
}
