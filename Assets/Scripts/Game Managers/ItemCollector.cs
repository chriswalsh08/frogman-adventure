using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    // initialize animator and audio source
    private Animator anim;
    public AudioSource audioSource;
    public AudioClip clip;
    [SerializeField] private float volume = .99f;

    // Animation states
    private enum MovementState { idle, fruitCollected }
    //private bool itemCollected = false;

    // initialize strawberry/score variables
    private int fruitPoints = 10;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {

            // play sound when item is collected
            audioSource.clip = clip;
            audioSource.PlayOneShot(audioSource.clip, volume);

            // TO DO: Despawn animation when strawberry is picked up

            // destroy strawberry once collected
            Destroy(collision.gameObject);

            // increment strawberry counter
            ScoreManager.Instance.IncreaseScore(fruitPoints);
        }
    }
}
