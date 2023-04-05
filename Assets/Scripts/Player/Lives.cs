using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public GameObject[] lifeImage;
    public GameObject gameOverUI;
    public static int health;

    // game over sound
    public static bool gameOver = false;
    public AudioSource audioSource;
    public AudioClip clip;
    [SerializeField] private float volume = .25f;

    void Start()
    {
        health = 3;
    }
    void Update()
    {

        // disable the life images upon death
        if (health < 1)
        {
            lifeImage[0].gameObject.SetActive(false);
        }
        else if (health < 2)
        {
            lifeImage[1].gameObject.SetActive(false);
        }
        else if (health < 3)
        {
            lifeImage[2].gameObject.SetActive(false);
        }

        if (health <= 0)
        {
            gameIsOver();
        }
    }

    // lose a life when the die(); method is called
    public static void LoseLife()
    {     
        health--;
    }

    // game over
    public void gameIsOver()
    {
        gameOver = true;
        gameOverUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        audioSource.clip = clip;
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
