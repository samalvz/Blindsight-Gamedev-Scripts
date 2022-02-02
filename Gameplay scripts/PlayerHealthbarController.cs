using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;
public class PlayerHealthbarController : MonoBehaviour
{
    //private player = Variables;
    private GameObject player;
    [SerializeField] private Healthbar healthbar;

    private int playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerhealth = (int)Variables.Object(player).Get("PlayerHealth");
        //healthbar.SetHp(playerhealth);
    }
}
