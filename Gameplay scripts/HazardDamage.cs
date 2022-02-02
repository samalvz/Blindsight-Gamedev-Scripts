using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

public class HazardDamage : MonoBehaviour
{
    public BoxCollider2D box;
    public GameObject player;

    private LayerMask spikeshazard;

    public float damage_interval = 1f;
    public int spike_damage;

    private float timer;

    public bool can_take_damage = false;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
        spikeshazard = LayerMask.GetMask("Spikes");
    }

    // Update is called once per frame
    void Update()
    {
        if (!can_take_damage && timer < damage_interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            can_take_damage = true;
            timer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (can_take_damage )
        {
            //Debug.Log("can take dam");
            if ((spikeshazard.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                //Debug.Log("Should b doin dam");
                can_take_damage = false;
                //int health = (int)Variables.Object(player).Get("PlayerHealth");
                //Variables.Object(player).Set("PlayerHealth", health - spike_damage);
                //CustomEvent.Trigger(player, "Vulnerable", spike_damage);
                CustomEvent.Trigger(player, "Damage", spike_damage, player);
            }
        }
        
    }
}
