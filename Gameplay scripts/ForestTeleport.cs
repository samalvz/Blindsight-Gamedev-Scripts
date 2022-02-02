using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestTeleport : MonoBehaviour
{
    public GameManager gm;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Sending player to forest");
            gm.passedScene = "Forest Level";
            SceneManager.LoadScene("Forest Level", LoadSceneMode.Single);
            gm.StartLevel();
        }
    }
}
