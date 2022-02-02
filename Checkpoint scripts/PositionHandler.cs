using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionHandler : MonoBehaviour
{
    private GameManager gm;
    private Transform player;
    
    [Header("Play from dropped position")]
    [Tooltip("You will not gather checkpoints if enabled" +
             "You will always begin at beginning of game if enabled")]
    public bool EnableFreeDrop = false;
    
    //[Header("Start at Beginning of Selected level (choose only one)")]
    //public bool Cemetary = false;

    //public bool Forest = false;
    
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GetComponent<Transform>();
        if (!EnableFreeDrop)
            player.position = gm.GetLastCheckpointPosition();
        
        // if (Cemetary)
        // {
        //     gm.passedScene = "Game Scene";
        //     gm.StartLevel();
        // }
        // else if (Forest)
        // {
        //     gm.passedScene = "Forest Level";
        //     gm.StartLevel();
        // }
        // else if (Forest)
        // {
        //     gm.passedScene = "Forest Level";
        //     gm.StartLevel();
        // }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        //Debug.Log("Last Checkpoint is: " + gm.lastCheckpointPosition);
    }

}
