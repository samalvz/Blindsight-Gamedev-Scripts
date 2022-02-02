using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public Animator animator;

    public bool alreadyon;

    public BonfireLight light;
    //private GameManager gm;
    //private GameObject player;
    //public GameObject Cpoint;
    void Start()
    {
        animator = GetComponent<Animator>();
        //gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //player = GameObject.Find("Player");
    }

    public void ignite()
    {
        animator.SetTrigger("Ignite");
        animator.SetBool("IsOn", true);
        if (!alreadyon)
        {
            GetComponent<AudioSource>().Play();
            new WaitForSeconds(10.0f);
            light.IgniteLight();
        }
            
    }

    public void BonfireOn()
    {
        animator.SetBool("AlreadyOn", true);
        alreadyon = true;
        light.LightOn();
    }
}
