using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // initialize variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private int extraJumps = 1;
    public int extraJumpsValue;

    // create a state enum for movement state
    private enum MovementState { idle, running, jumping, falling, doubleJumping }

    // Play sound effects
    public AudioSource audioSource;
    public AudioClip clip;
    [SerializeField] private float volume = .25f;

    // Start is called before the first frame update
    private void Start()
    {
        // initialize components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        extraJumps = extraJumpsValue;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        // Move left and right!
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Jump -- Vector3 holds 3 values; X Y and Z coords - Vector2 holds X and Y

        // if the player is grounded, reset their jump count
        if (IsGrounded())
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            PlayAudio();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && IsGrounded())
        {
            PlayAudio();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    // update player animation based on their state
    private void UpdateAnimationState()
    {
        dirX = Input.GetAxis("Horizontal");
        MovementState state;

        // Determine if player is moving horizontally
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // determine if force is moving up or down on player
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;

            if (state == MovementState.jumping && Input.GetButtonDown("Jump"))
            {
                state = MovementState.doubleJumping;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    // check to see if collision has occurred so player can jump again
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void PlayAudio()
    {
        audioSource.clip = clip;
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
