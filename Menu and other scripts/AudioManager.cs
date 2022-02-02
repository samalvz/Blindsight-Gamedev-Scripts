using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;
    public static AudioManager BGInstance;

    private void Awake()
    {
        if(BGInstance == null)
        {
            BGInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //if (BGInstance != null && BGInstance != this)
        //{
        //    Destroy(this.gameObject);
        //    return;
        //}
        //else
        //{
        //    BGInstance = this;
        //}

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name)
        {
            return;
        }
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
