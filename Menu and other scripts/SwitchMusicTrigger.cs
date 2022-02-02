using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager theAM;
    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(newTrack != null)
            {
                //Debug.Log("Trigger");
                theAM.ChangeBGM(newTrack);
            }
        }
    }
}
