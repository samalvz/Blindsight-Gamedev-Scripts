using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameFading : MonoBehaviour
{
    public Image victory;

    public Image quitgame;

    float fadeinspeed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        Color color = new Color(255, 255, 255, 0);
        victory.color = color;
        quitgame.color = color;
        
        StartCoroutine(waiting(victory, .8f));
        StartCoroutine(waiting(quitgame, 1.7f));
    }

    private IEnumerator FadeIn(Image image)
    {
        while ((image.color.a < 1))
        {
            Color color = image.color;
            float fadeamount = color.a + (fadeinspeed * Time.deltaTime);
            color.a = fadeamount;
            image.color = color;
            yield return null;
        }
    }

    IEnumerator waiting(Image image, float waitamount)
    {
        yield return new WaitForSeconds(waitamount);
        StartCoroutine(FadeIn(image));
    }
}
