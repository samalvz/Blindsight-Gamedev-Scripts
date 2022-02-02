using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

public class CPoint : MonoBehaviour
{
    private GameManager gm;
    private Transform trs;
    private GameObject player;
    public Bonfire bonfire;
    private UIPlayerEvent player_ui;
    public int cpointnumber;
    private bool bonfire_ignited;
    private bool cpointfound;
    //public BoxCollider2D box;

    void Start()
    {
        // get cpointmaster script
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        trs = GetComponent<Transform>();
        player = GameObject.Find("Player");
        player_ui = player.GetComponent<UIPlayerEvent>();
        if (gm.GetLastCheckpointRegistered() >= cpointnumber)
        {
            //Debug.Log("checkpoint " + cpointnumber + " already on");
            bonfire_ignited = true;
            bonfire.BonfireOn();
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Cpoint area entered");
        if (collider.CompareTag("Player") && !cpointfound)
        {
            cpointfound = true;
            Variables.Object(player).Set("PlayerHealth", 20);   // give player maxHP
            gm.SetLastCheckpointPosition(trs.position);
            //Debug.Log("checkpoint saved at pos: + " + trs.position);
            player_ui.CheckpointNotification(); // displays checkpoint text on UI 
            gm.RegisterCheckpoint(cpointnumber);

            if (!bonfire_ignited)
            {
                bonfire.ignite();
            }
        }
    }
}
