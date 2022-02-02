using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class SamBlock : MonoBehaviour
{
    //SFX
    public AudioSource jump;
    // movement
    public float moveSpeed;
    public float jumpForce;
    private float horizontalVelocity;
    // advanced movement
    [SerializeField] float horizontalAcceleration;
    [SerializeField] [Range(0, 1)] float horizontalDampening;
    [SerializeField] [Range(0, 1)] float horizDampStopping;
    [SerializeField] [Range(0, 1)] float horizDampTurning;
    [SerializeField] [Range(0, 1)] float airDampening;

    // unity
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask ground;
    public Transform groundCheck1, groundCheck2;
    
    // jumping 
    public bool isGrounded;
    //private float jumpTimeCounter;
    public float hangTime = .05f;         // how long player has to jump if not grounded
    private float hangCounter;            // counts down hang timer
    public float jumpBufferLength = .1f;  // how much time player has to buffer a jump
    private float jumpBufferCount;        // counts down jump buffer timer



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        // check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck1.position, .1f, ground) || Physics2D.OverlapCircle(groundCheck2.position, .1f, ground);
        
        //if (horizontalVelocity > 0.1)
        //{
        //    sprite.flipX = false;
        //} else if (horizontalVelocity < -0.1) {
        //    sprite.flipX = true;
        //}
        
        // handle hang time 
        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else 
        {
            hangCounter -= Time.deltaTime;
        }
        
        // handle jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            jump.Play();
            jumpBufferCount = jumpBufferLength;
        } 
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }
        
        // jump key is let go
        if (Input.GetButtonUp("Jump") && (rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
        
        // jump key is held
        if (jumpBufferCount >= 0 && (hangCounter > 0))
        {
            jumpBufferCount = 0;
            hangCounter = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
    }
    void FixedUpdate()
    {
        // TODO possibly move expensive calculations to update -> this drastically changes speeds, possibly rewrite entirely

        horizontalVelocity = rb.velocity.x;
        horizontalVelocity += Input.GetAxisRaw("Horizontal") * moveSpeed;                          // acceleration on input movement

        if (Math.Abs(Input.GetAxisRaw("Horizontal")) < .01f)                                        // dampen when stopping (not holding A or D)
        {   
            //Debug.Log("< 0.01f" + Input.GetAxisRaw("Horizontal"));
            horizontalVelocity *= Mathf.Pow(1f - horizDampStopping, Time.deltaTime * 10f);
        }
        else if (Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVelocity))    // dampen when turning
            horizontalVelocity *= Mathf.Pow(1f - horizDampTurning, Time.deltaTime * 10f);
        else if (!isGrounded)
            horizontalVelocity *= Mathf.Pow(1f - airDampening, Time.deltaTime * 10f);
        else
            horizontalVelocity *= Mathf.Pow(1f - horizontalDampening, Time.deltaTime * 10f);   // dampening acceleration whilst moving forwards
        
        
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);                            // move character
        //Debug.Log(horizontalVelocity);
    }

    
    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Debug.Log("inside rock collider!");
    //}
}
