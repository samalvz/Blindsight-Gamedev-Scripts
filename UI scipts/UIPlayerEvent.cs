using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPlayerEvent : MonoBehaviour
{
    [SerializeField] private Image CheckpointText;
    private GameObject player;
    public float fadeinspeed1;
    public float fadeoutspeed1;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void CheckpointNotification()
    {
        StartCoroutine(FadeIn(CheckpointText));
        //StartCoroutine(Wait(2f));
        //StartCoroutine(FadeOut(CheckpointText));
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
    }
    private IEnumerator FadeIn(Image image)
    {
        while ((image.color.a < 1))
        {
            Color color = image.color;
            float fadeamount = color.a + (fadeinspeed1 * Time.deltaTime);
            color.a = fadeamount;
            image.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeOut(CheckpointText));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
