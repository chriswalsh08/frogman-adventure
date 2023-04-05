using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    // reference components
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject Player;

    // sound components
    public AudioSource audioSource;
    public AudioClip clip;
    [SerializeField] private float volume = .99f;

    private void Start()
    {
        // Set up components
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {

            Die();
            Lives.LoseLife();
            Debug.Log(Lives.health);
        }
    }

    private void Die()
    {
        // play audio
        audioSource.clip = clip;
        audioSource.PlayOneShot(audioSource.clip, volume);

        // death animation
        anim.SetTrigger("death");

        // disable movement
        Player.GetComponent<PlayerMovement>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        ScoreManager.Instance.ResetLevelScore();

        // TO DO: SET RESPAWN ANIMATIOn
    }
}
