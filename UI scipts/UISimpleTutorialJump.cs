using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISimpleTutorialJump : MonoBehaviour
{
    public GameObject Shiftup;
    public GameObject Shiftdn;

    private SpriteRenderer sup;
    private SpriteRenderer sdn;

    public float fadespeed;
    public float flashtime;
    public float notflashtime;
    private bool inside;
    private bool runningInside = false;

    void Start()
    {
        sup = Shiftup.GetComponent<SpriteRenderer>();
        sdn = Shiftdn.GetComponent<SpriteRenderer>();
        sdn.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inside = true;
            StartCoroutine(FadeIn());
            if (!runningInside)
                StartCoroutine(FlashSpace());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOut());
            StartCoroutine(DisableObjects());
        }

    }
    
    private IEnumerator FadeOut()
    {
        while (sup.color.a > 0)
        {
            Color color = sup.color;
            float fadeamount = color.a - (fadespeed * Time.deltaTime);
            color.a = fadeamount;
            sup.color = color;
            sdn.color = color;
            yield return null;
        }
        inside = false;
    }
    
    private IEnumerator FadeIn()
    {
        while ((sup.color.a < 1))
        {
            Color color = sup.color;
            float fadeamount = color.a + (fadespeed * Time.deltaTime);
            color.a = fadeamount;
            sup.color = color;
            sdn.color = color;
            yield return null;
        }
    }
    private IEnumerator FlashSpace()
    {
        runningInside = true;
        //yield return new WaitForSeconds(0.2f);
        while (inside)
        {
            yield return new WaitForSeconds(notflashtime);
            sdn.enabled = true;
            yield return new WaitForSeconds(flashtime);
            sdn.enabled = false;
        }

        runningInside = false;
    }
    private IEnumerator DisableObjects()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine(FadeOut());
        Shiftdn.SetActive(false);
        Shiftup.SetActive(false);
        enabled = false;
    }
}