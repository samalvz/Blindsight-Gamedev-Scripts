﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
