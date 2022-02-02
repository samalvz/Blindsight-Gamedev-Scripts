using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Tobecontinuedcam : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;

    public GameObject Player;
    private Transform playerpos;
    private Transform stopfollowpos;

    private void Start()
    {
        playerpos = Player.transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // start following
        if (other.CompareTag("Player"))
        {
            cam1.Follow = Player.transform;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        // stop following
        
    }
}
