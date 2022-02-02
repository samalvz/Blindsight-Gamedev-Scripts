using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cemetaryCam1 : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        
        cam1.gameObject.SetActive(true);
        cam1.MoveToTopOfPrioritySubqueue();  
    }
    void OnTriggerStay2D(Collider2D other)
    {
        //cam1.gameObject.SetActive(true);
        cam1.MoveToTopOfPrioritySubqueue();  
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        cam1.gameObject.SetActive(false);
    }
}