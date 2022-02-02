using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Bolt;
using Ludiq;

public class CemetaryBossScript : MonoBehaviour
{
    //public BoxCollider2D wall1;         // confines player on the left
    public BoxCollider2D wall2;         // confines player on the right
    
    public CinemachineVirtualCamera bosscam;
    //public CinemachineVirtualCamera roomcam;
    public GameObject boss;
    private float bosshp;

    void Start()
    {
        bosscam.gameObject.SetActive(false);
        //boss = GameObject.Find("Caretaker");
    }

    void Update()
    {
        bosshp = (float) Variables.Object(boss).Get("Health");

        if (bosshp < 1)
        {
            BossDeath();
        }
    }

    void BossDeath()
    {
        // boss hp 0
        wall2.enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // enable barriers
        if (other.CompareTag("Player"))
        {
            //cam1.gameObject.SetActive(true);
            //bosscam.MoveToTopOfPrioritySubqueue();
        }
    }
    
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bosscam.gameObject.SetActive(true);
            bosscam.MoveToTopOfPrioritySubqueue();
        } 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // disactivate boss cam
        if (other.CompareTag("Player"))
        {
            bosscam.gameObject.SetActive(false);
        }

        if (other.CompareTag("Enemy"))
        {
            // debug for when boss falls through ground
            Debug.Log("Boss fell through");
            //wall2.enabled = false;
        }
    }
}
