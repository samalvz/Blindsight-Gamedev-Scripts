using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterBehavior : MonoBehaviour
{
    public SamBlock player;
    public Rigidbody2D rb;
    
    //  original values
    private float movespeed = 1.7f;
    private float gravity = 0.5f;
    private float jumpforce = 20;


    // underwater values
    private float underwaterspeed = .85f;
    private float underwatergravity = .4f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.moveSpeed = underwaterspeed;
        player.jumpForce = 10;
        rb.gravityScale = .05f;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        player.moveSpeed = movespeed;
        player.jumpForce = jumpforce;
        rb.gravityScale = gravity;
    }
}
