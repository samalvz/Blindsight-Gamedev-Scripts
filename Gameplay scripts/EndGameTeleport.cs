using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTeleport : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Sending player to cathedral");
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
        }
    }
}
