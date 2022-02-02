using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tbcfadein : MonoBehaviour
{
    public GameObject image;
    private SpriteRenderer text;

    public float fadespeed;

    void Start()
    {
        text = image.GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeIn());
        }
    }
    private IEnumerator FadeIn()
    {
        while ((text.color.a < 1))
        {
            Color color = text.color;
            float fadeamount = color.a + (fadespeed * Time.deltaTime);
            color.a = fadeamount;
            text.color = color;
            yield return null;
        //Debug.Log("woring on tbc");
        }
    }
}
