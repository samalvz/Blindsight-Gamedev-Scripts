using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireLight : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public Bonfire bonfire;
    void Start()
    {
        //light.intensity = 0f;
    }

    void Awake()
    {
        light.intensity = 0f;
    }

    public void IgniteLight()
    {
        StartCoroutine("Ignite");
    }

    public void LightOn()
    {
        light.intensity = 2f;
        //Debug.Log(light.name + " intensity = " + light.intensity);
    }

    IEnumerator Ignite()
    {
        light.enabled = true;
        yield return new WaitForSeconds(2.1f);
        light.intensity = 6f;
        yield return new WaitForSeconds(2.125f);
        light.intensity = 8f;
        yield return new WaitForSeconds(2.035f);
        light.intensity = 4f;
        yield return new WaitForSeconds(2.2f);
        light.intensity = 2f;
    }

}
