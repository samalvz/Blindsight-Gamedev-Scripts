using System;
using System.Collections;
using System.Collections.Generic;
using Ludiq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gm;
    private static Vector3 lastCheckpointPosition;
    public static int lastCheckpointRegistered;
    private Scene scene;
    public string passedScene = "";

    // checkpoints
    #region
    public bool cpoint0;
    public bool cpoint1;
    public bool cpoint2;
    public bool cpoint3;
    public bool cpoint4;
    public bool cpoint5;
    public bool cpoint6;
    public bool cpoint7;
    public bool cpoint8;
    public bool cpoint9;
    public bool cpoint10;
    public bool cpoint11;
    public bool cpoint12;
    public bool cpoint13;
    public bool cpoint14;
    public bool cpoint15;
    public bool cpoint16;
    public bool cpoint17;
    public bool cpoint18;
    public bool cpoint19;
    public bool cpoint20;
    #endregion
    
    void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this.GameObject());
            return;
        }
        else
        {
            gm = this;
        }
        DontDestroyOnLoad(this.GameObject());
    }

    void Start()
    {
        Debug.Log("started:)");
        scene = SceneManager.GetActiveScene();
        StartPosition(passedScene);
    }

    public void StartLevel()
    {
        scene = SceneManager.GetActiveScene();
        StartPosition(passedScene);
    }
    

    // This only registers checkpoints for bonfires and does not store locations
    public void RegisterCheckpoint(int cpointnum)
    {
        switch (cpointnum)
        {
            case 0:
                cpoint0 = true;
                lastCheckpointRegistered = 0;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 1:
                cpoint1 = true;
                lastCheckpointRegistered = 1;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 2:
                cpoint2 = true;
                lastCheckpointRegistered = 2;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 3:
                cpoint3 = true;
                lastCheckpointRegistered = 3;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 4:
                cpoint4 = true;
                lastCheckpointRegistered = 4;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 5:
                cpoint5 = true;
                lastCheckpointRegistered = 5;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 6:
                cpoint6 = true;
                lastCheckpointRegistered = 6;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 7:
                cpoint7 = true;
                lastCheckpointRegistered = 7;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 8:
                cpoint8 = true;
                lastCheckpointRegistered = 8;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 9:
                cpoint9 = true;
                lastCheckpointRegistered = 9;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 10:
                cpoint10 = true;
                lastCheckpointRegistered = 10;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 11:
                cpoint11 = true;
                lastCheckpointRegistered = 11;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 12:
                cpoint12 = true;
                lastCheckpointRegistered = 12;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 13:
                cpoint13 = true;
                lastCheckpointRegistered = 13;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 14:
                cpoint14 = true;
                lastCheckpointRegistered = 14;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 15:
                cpoint15 = true;
                lastCheckpointRegistered = 15;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 16:
                cpoint16 = true;
                lastCheckpointRegistered = 16;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 17:
                cpoint17 = true;
                lastCheckpointRegistered = 17;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 18:
                cpoint18 = true;
                lastCheckpointRegistered = 18;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 19:
                cpoint19 = true;
                lastCheckpointRegistered = 19;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            case 20:
                cpoint20 = true;
                lastCheckpointRegistered = 20;
                Debug.Log("registered cpoint " + cpointnum );
                break;
            
            default:
                Debug.Log("Checkpoint has no register number (cpoint.cs)");
                break;
        }
    }
    
    public void SetLastCheckpointPosition(Vector3 location)
    {
        lastCheckpointPosition = location;
    }

    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    // needed since vector3 is not serializable (used for saving game)
    public float[] GetSavedCheckpoint()
    {
        float[] cp_pos = new float[3];
        cp_pos[0] = lastCheckpointPosition[0];
        cp_pos[1] = lastCheckpointPosition[1];
        cp_pos[2] = lastCheckpointPosition[2];
        return cp_pos;
    }
    
    public int GetLastCheckpointRegistered()
    {
        return lastCheckpointRegistered;
    }
    
    void StartPosition(string scene)
    {
        Debug.Log("passed string:" + scene);
        //if (scene.name == "Game Scene")
        if (String.Compare(scene, "Game Scene") == 0)
        {
            Debug.Log("Game Level");
            if (lastCheckpointRegistered < 1)
            {
                lastCheckpointPosition= new Vector3(-54.28f, -51.1f, 0f);
            }
            
        }
        if (String.Compare(scene, "Forest Level") == 0) 
        {
            Debug.Log("Forest Level");
            lastCheckpointPosition = new Vector3(-20f, 1.65f, 0f);
            Debug.Log("forest level detected");
            //if (lastCheckpointRegistered < 5)  // first forest checkpoint is 5
            //{
                //Debug.Log("Forest Level");
                //lastCheckpointPosition = new Vector3(-20f, 1.65f, 0f);
            //}
        }

        if (String.Compare(scene, "Cathedral Level") == 0)
        {
            Debug.Log("Cathedral Level");
            lastCheckpointPosition = new Vector3(-9.6f, 0, 0);
            
        }
        else
        {
            Debug.LogWarning("Unnamed Scene or scene not sent to GM with name");
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game Scene", LoadSceneMode.Single);
        
            cpoint0 = false;
            cpoint1 = false;
            cpoint2 = false;
            cpoint3 = false;
            cpoint4 = false;
            cpoint5 = false;
            cpoint6 = false;
            cpoint7 = false;
            cpoint8 = false;
            cpoint9 = false;
            cpoint10 = false;
            cpoint11 = false;
            cpoint12 = false;
            cpoint13 = false;
            cpoint14 = false;
            cpoint15 = false;
            cpoint16 = false;
            cpoint17 = false;
            cpoint18 = false;
            cpoint19 = false;
            cpoint20 = false;
        
        lastCheckpointRegistered = 0;
        lastCheckpointPosition= new Vector3(-54.28f, -51.1f, 0f);
        Time.timeScale = 1;
    }

}
