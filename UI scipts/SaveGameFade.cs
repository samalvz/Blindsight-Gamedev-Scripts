using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameFade : MonoBehaviour
{
    [SerializeField] private Image SaveText;
    public float fadeinspeed1;
    public float fadeoutspeed1;

    public void SavedGameAppear()
    {
        StartCoroutine(AppearIn(SaveText));
    }
    
    private IEnumerator FadeOut(Image image)
    {
        while (image.color.a > 0)
        {
            Color color = image.color;
            float fadeamount = color.a - ((fadeoutspeed1) * Time.deltaTime);
            color.a = fadeamount;
            image.color = color;
            yield return null;
        }

        image.enabled = false;
        
    }
    private IEnumerator AppearIn(Image image)
    {
        Color color = image.color;
        color.a = 1;
        image.color = color;
        image.enabled = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeOut(SaveText));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
