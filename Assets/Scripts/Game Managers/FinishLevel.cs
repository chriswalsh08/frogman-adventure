using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLevel : MonoBehaviour
{
    // sound stuff
    public AudioSource audioSource;
    public AudioClip clip;
    [SerializeField] private float volume = .99f;



    // serialized field for transition to the next level
    [SerializeField] private float transitionTimer = 2f;

    // boolean for level completed sound
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;

            // save the score to reset to if the player dies in the next level
            ScoreManager.Instance.SaveLevelScore();

            // play level completed audio
            audioSource.clip = clip;
            audioSource.PlayOneShot(audioSource.clip, volume);

            // wait before loading next level
            Invoke("LevelTransition", transitionTimer);
        }
    }

    private void LevelTransition()
    {
        // load the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
