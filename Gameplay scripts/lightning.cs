using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class lightning : MonoBehaviour
{

    [SerializeField] UnityEngine.Experimental.Rendering.Universal.Light2D light1, light2, light3, light4;

    public float timer;
    public float flash_time;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timer = Random.Range(3f, 5f);
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light4.enabled = false;
        light1.intensity = 6.45f;
        light2.intensity = 3f;
        light3.intensity = 3f;
        light4.intensity = 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (time < timer)
        {
            time += Time.deltaTime;
        }
        else
        {
            StartCoroutine("go");
            timer = Random.Range(6f, 10f);
            time = 0;
        }
    }
    
    IEnumerator go()
    {
        //Debug.Log("Lightning!");
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        light4.enabled = true;
        yield return new WaitForSeconds(flash_time);
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light4.enabled = false;
        yield return new WaitForSeconds(flash_time - .025f);
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        light4.enabled = true;
        yield return new WaitForSeconds(flash_time - .035f);
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light4.enabled = false;
        //yield return 0;
    }
}
