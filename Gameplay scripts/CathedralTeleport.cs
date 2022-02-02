using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CathedralTeleport : MonoBehaviour
{
    public GameManager gm;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Sending player to cathedral");
            gm.passedScene = "Cathedral Level";
            SceneManager.LoadScene("Cathedral Level", LoadSceneMode.Single);
            gm.StartLevel();
        }
    }
}
