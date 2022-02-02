using System;
using System.Collections;
using System.Collections.Generic;
using Ludiq;
using UnityEditor;
using UnityEngine;

public class UISimpleTutorialCollider : MonoBehaviour
{
    //private GameObject W = GameObject.Find("W");
    //private GameObject A = GameObject.Find("A");
    //private GameObject S = GameObject.Find("S");
    //private GameObject D = GameObject.Find("D");

    public GameObject W;
    public GameObject A;
    public GameObject S;
    public GameObject D;
    public GameObject Df;

    private SpriteRenderer wk;
    private SpriteRenderer ak;
    private SpriteRenderer sk;
    private SpriteRenderer dk;
    private SpriteRenderer df;
    public float fadespeed;
    public float flashtime;
    public float notflashtime;
    private bool inside;
    private bool runningInside = false;
    void Start()
    {
        wk = W.GetComponent<SpriteRenderer>();
        ak = A.GetComponent<SpriteRenderer>();
        sk = S.GetComponent<SpriteRenderer>();
        dk = D.GetComponent<SpriteRenderer>();
        df = Df.GetComponent<SpriteRenderer>();
        df.enabled = false; 

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inside = true;
            StartCoroutine(FadeIn());
            if (!runningInside)
                StartCoroutine(FlashD());
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
        while (wk.color.a > 0)
        {
            Color color = wk.color;
            float fadeamount = color.a - (fadespeed * Time.deltaTime);
            color.a = fadeamount;
            wk.color = color;
            ak.color = color;
            sk.color = color;
            dk.color = color;
            df.color = color;
            yield return null;
        }
        inside = false;
    }
    
    private IEnumerator FadeIn()
    {
        while ((wk.color.a < 1))
        {
            Color color = wk.color;
            float fadeamount = color.a + (fadespeed * Time.deltaTime);
            color.a = fadeamount;
            wk.color = color;
            ak.color = color;
            sk.color = color;
            dk.color = color;
            df.color = color;
            yield return null;
        }
    }

    private IEnumerator FlashD()
    {
        runningInside = true;
        yield return new WaitForSeconds(0.6f);
        while (inside)
        {
            yield return new WaitForSeconds(notflashtime);
            df.enabled = true;
            yield return new WaitForSeconds(flashtime);
            df.enabled = false;
        }

        runningInside = false;
    }

    private IEnumerator DisableObjects()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine(FadeOut());
        W.SetActive(false);
        A.SetActive(false);
        S.SetActive(false);
        D.SetActive(false);
        Df.SetActive(false);
    }
    
}
