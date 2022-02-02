using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchFix : MonoBehaviour
{
    public BoxCollider2D detector; // above the object

    public BoxCollider2D platform; // can stand on this
    // Start is called before the first frame update
    void Start()
    {
        platform.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            platform.enabled = true;
        }
    }
}
