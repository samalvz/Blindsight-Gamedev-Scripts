using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Private
    private GameObject playerobject;
    private Transform trans;
    private Healthbar PlayerHealth;
    private GameManager gm;
    private int Checkpoint;

    // public (not actually needed?)
    private int health;
    private Vector3 position;
    private int checkpoint;

    void Start()
    {
        playerobject = GameObject.Find("Player");
        trans = playerobject.GetComponent<Transform>();              
        PlayerHealth = playerobject.GetComponent<Healthbar>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    

    public void SavePlayer()
    {
        //checkpoint = gm.GetLastCheckpointRegistered(); // get latest just in case
        SaveSystem.SavePlayer(this);
        Debug.Log("Player Saved");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        
        checkpoint = data.checkpoint_number;
        LoadHandler(checkpoint);
        
        health = data.health;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        Time.timeScale = 1; // need to set this because pause menu sets timescale to 0 and bugs game
        Debug.Log("Player Loaded");
    }

    void LoadHandler(int lastcheckpoint)
    {
        Debug.Log("Last Checkpoint: " + lastcheckpoint);
        if (lastcheckpoint <= 4)
        {
            SceneManager.LoadScene("Game Scene", LoadSceneMode.Single);
            Debug.Log("Game scene was the one saved");
        }
        
        else if (lastcheckpoint >= 12)
        {
            SceneManager.LoadScene("Cathedral Level", LoadSceneMode.Single);
            Debug.Log("cathedral scene was the one saved");
        }

        else if (lastcheckpoint >= 5)
        {
            SceneManager.LoadScene("Forest Level", LoadSceneMode.Single);
            Debug.Log("forest scene was the one saved");
        }
        
    }
    
    
    public int GetHealth()
    {
        return (int) PlayerHealth.current_hp;
    }

    public float[] GetCheckpoint()
    {
        return gm.GetSavedCheckpoint();
    }
    
    public int GetLastRegisteredCheckpoint()
    {
        return gm.GetLastCheckpointRegistered();
    }
}
