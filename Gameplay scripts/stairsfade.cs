using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

public class stairsfade : MonoBehaviour
{
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    
    public GameObject boss;
    private float bosshp;
    // Start is called before the first frame update
    void Start()
    {
        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bosshp = (float) Variables.Object(boss).Get("Health");

        if (bosshp < 1)
        {
            Stairs();
        }
    }

    void Stairs()
    { 
        StartCoroutine(StepWait(step1, 1));
        StartCoroutine(StepWait(step2, 2));
        StartCoroutine(StepWait(step3, 3));
    }
    
    IEnumerator StepWait(GameObject step, int stepnumber)
    {
        yield return new WaitForSeconds(1f * stepnumber);
        step.SetActive(true);
    }
}
