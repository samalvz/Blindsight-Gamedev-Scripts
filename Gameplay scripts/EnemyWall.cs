using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    BoxCollider2D box;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(box, other.collider);
        }
    }
}
