using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPortal : MonoBehaviour
{
    [SerializeField] GameObject PortalReceiver;

    [SerializeField] GameObject Player;

    private float teleportTimer = 1f;
    [SerializeField] float nextTeleport = 1f;
    private bool teleport = true;

    void Update()
    {
        if (teleport == false)
        {
            teleportTimer =- Time.deltaTime;
        }

        if (teleportTimer < 0)
        {
            teleport = true;
            teleportTimer = nextTeleport;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && teleport == true)
        {
            Player.transform.position =
                new Vector2(PortalReceiver.transform.position.x, PortalReceiver.transform.position.y);
            teleport = false;
        }
    }
}
