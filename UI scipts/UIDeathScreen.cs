using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bolt;
using Ludiq;

public class UIDeathScreen : MonoBehaviour
{
    private float current_hp;
    [SerializeField] private Image background, f, ded, startfadein, continuetext;
    private GameObject player;
    private int health;
    public float fadeoutspeed;
    public float fadeinspeed;
    private bool started;

    void Start()
    {
        player = GameObject.Find("Player");
        health = (int) Variables.Object(player).Get("PlayerHealth");
        startfadein.enabled = true;
        StartCoroutine(FadeOut(startfadein));
    }



    // Update is called once per frame
    void Update()
    {

        health = (int) Variables.Object(player).Get("PlayerHealth");
        if (health <= 0)
        {
            StartCoroutine(ShowDeath());
        }

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    CustomEvent.Trigger(player, "Damage", 20, player);
        //}
    }
    
    private IEnumerator FadeOut(Image image)
    {
        while (image.color.a > 0)
        {
            Color color = image.color;
            float fadeamount = color.a - ((fadeoutspeed * 1.5f) * Time.deltaTime);
            color.a = fadeamount;
            image.color = color;
            yield return null;
        }

        startfadein.enabled = false;
    }

    private IEnumerator ShowDeath()
    {
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(FadeIn(background));
        StartCoroutine(FadeIn(ded));
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeIn(f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeIn(continuetext));
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
    

}