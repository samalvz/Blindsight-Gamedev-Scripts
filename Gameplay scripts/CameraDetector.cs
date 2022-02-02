using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDetector : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.gameObject.SetActive(true);
            cam.MoveToTopOfPrioritySubqueue();
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //cam1.gameObject.SetActive(true);
            cam.MoveToTopOfPrioritySubqueue();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //cam1.gameObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            cam.gameObject.SetActive(false);
        }
    }
}
