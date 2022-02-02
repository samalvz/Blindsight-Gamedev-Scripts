using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public int damage = 250;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CustomEvent.Trigger(player, "Damage", damage, player);
        }
    }
}
