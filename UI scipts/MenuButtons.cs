using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuButtons : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI tmpro;
    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        tmpro = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        if (animator.GetBool("Highlighted"))
        {
            tmpro.color = new Color32(0, 0, 0, 255);
            Debug.Log("Highlighted");
        }
        
    }
}
