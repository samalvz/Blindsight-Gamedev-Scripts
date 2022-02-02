using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashSequence : MonoBehaviour
{
    public static int SceneNumber;

    public Image splashImage;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(ToSplashTwo ());
        }
        if(SceneNumber == 1)
        {
            StartCoroutine(ToMainMenu ());
        }    
    }

    IEnumerator ToSplashTwo()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }

    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(2.5f);
        SceneNumber = 2;
        SceneManager.LoadScene(2);
    }

    //fade in and out functions
    public void FadeIn()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    public void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
