using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private Vector2 pos1, pos2;
    [SerializeField] private Transform box;
    public GameObject player;
    private Rigidbody2D prb;
    
    // Movement speed in units per second.
    public float speed;

    // Time when the movement started.
    private float startTime;
    // Total distance between the markers.
    private float journeyLength;

    private bool go = false;

    private float timeE;

    private float startval = 0;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = new Vector2(58.499f, -68.505f);
        pos2 = new Vector2(58.499f, -64.47f);
        startTime = Time.time;
        // Calculate the journey length.
        journeyLength = Vector2.Distance(pos1, pos2);
        prb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log(box.position.x + " pos2.x: " + pos2.x );
        //Debug.Log(box.position.y + " pos2.y: " + pos2.y );
        if (go)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;
            //box.position = new Vector2(box.position.x, box.position.y + speed * Time.deltaTime);
            box.position = Vector2.Lerp(pos1, pos2, fractionOfJourney);
        }
    }
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.parent = box.transform.parent;
            player.transform.SetParent(box);
            go = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out of collider");
        if (other.CompareTag("Player"))
        {
            player.transform.SetParent(null);
        }
        prb.AddForce(new Vector2(0f, 500f));
    }
}
