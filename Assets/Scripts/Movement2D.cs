using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    public float moveSpeed = 10f;   //speed for horizontal movement
    public float jumpForce = 10f;   //force when jumping
    public bool isGrounded;         //indicates when grounded
    private SpriteRenderer sprite;   //reference for sprite renderer comp
    Rigidbody2D rb;         //reference for rigidbody2d comp
    private Animator anim;     //reference to animator comp

    //for dashing
    private bool canDash = true;         //allows dash
    private bool isDashing;             //indicates if dashing
    private float dashingPower = 20f;    //dashing power
    private float dashingTime = 0.8f;     //duration for dash
    private float trailDuration = 0.1f;
    private float dashingCooldown = 1f;    //cooldown between dashes

    public bool isFloating = false;
    public bool isHurt = false;

    private enum MovementState { idle, walking, running, jumping, falling, floating, hurting}

    //for double-jump
    public bool doubleJump;

    [SerializeField] private TrailRenderer tr;   //reference to trailrenderer comp

    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //flip character's sprited based on direction facing
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sprite.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sprite.flipX = true;
        }

        //handel dashing if left shift is pressed and dash in allowed
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        //update character animation based on movement
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {

        MovementState state;

        //For Running Animation
        //update character animation based on movement

        //"Running animation is set to true when moving horizontal.
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            state = MovementState.walking;
        }
    
        else
        {
            state = MovementState.idle;
        }


        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        if (isDashing)
        {
            state = MovementState.running;
        }

        if (isFloating)
        {
            state = MovementState.floating;
        }

        if (isHurt)
        {
            state = MovementState.hurting;
        }


        anim.SetInteger("state", (int)state);
    }

    void Jump()
    {
        if (isDashing)  
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            //if jump buttob is pressed and characyer is grounded for had double jump left, apply jump force
            Debug.Log("Jumping");
            if (isGrounded || doubleJump)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0f, jumpForce));
                doubleJump = !doubleJump;
            }
        }

        if (isGrounded && !Input.GetButton("Jump"))
        {
            //resets jouble jump is character is grounded
            doubleJump = false;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // dash to left or right based on where you are facing
        if (sprite.flipX)
        {
            rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        }
        else
        {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }

        tr.emitting = true;   //enable the trailrender for dash effect
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;    //disabled trailrenderer after dashing
        yield return new WaitForSeconds(trailDuration);
        rb.gravityScale = originalGravity;   //restore the original gravity
        isDashing = false;
        yield return new WaitForSecondsRealtime(dashingCooldown);
        canDash = true;   //enable dashing again after cooldown
    }
}

