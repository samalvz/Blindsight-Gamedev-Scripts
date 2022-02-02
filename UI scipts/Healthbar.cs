using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
using Bolt;
using Ludiq;

public class Healthbar : MonoBehaviour
{
    private float max_player_health, current_hp_slow;
    public float current_hp;
    [SerializeField] private Image fast_bar, slow_bar;
    private float t = 0;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        max_player_health = (int)Variables.Object(player).Get("PlayerHealth");
        current_hp = max_player_health;
        current_hp_slow = max_player_health;
    }
    
    void Update()
    {
        current_hp = (int)Variables.Object(player).Get("PlayerHealth");
        //Debug.Log("Current hp: " + current_hp + "current slow hp: " + current_hp_slow);
        if (current_hp_slow != current_hp)
        {
            current_hp_slow = Mathf.Lerp(current_hp_slow, current_hp, t);
            t += .01f * Time.deltaTime; // change this float to modify drain speed (lower is slower)
        }
        else
        {
            t = 0;
        }
        fast_bar.fillAmount = current_hp / max_player_health;
        slow_bar.fillAmount = current_hp_slow / max_player_health;

        //if (Input.GetKeyDown(KeyCode.X))
        //{
            //CustomEvent.Trigger(player, "Damage", 20, player);
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
            //CustomEvent.Trigger(player, "Damage", 5, player);
        //}
    }

    public float GetCurrentHP()
    {
        return current_hp;
    }
}
