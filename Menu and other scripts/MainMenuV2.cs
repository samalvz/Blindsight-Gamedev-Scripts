using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuV2 : MonoBehaviour
{
    public GameManager gm;
    public void PlayGame()
    {
        gm.passedScene = "Game Scene";
        SceneManager.LoadScene("Game Scene", LoadSceneMode.Single);
        gm.NewGame();
    }

    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
