using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] string _volumeParameter;
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
        
    }

    private void HandleSliderValueChanged(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
        
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }
    //public AudioSource AudioSource;
    //private float musicVolume = 1f;
    //public Slider volumeSlider;
    //public static int SceneNumber;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //AudioSource.Play();
    //    musicVolume = PlayerPrefs.GetFloat("volume");
    //    AudioSource.volume = musicVolume;
    //    volumeSlider.value = musicVolume;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    AudioSource.volume = musicVolume;
    //    PlayerPrefs.SetFloat("volume", musicVolume);
    //}

    //public void updateVolume(float volume)
    //{
    //    musicVolume = volume;
    //}
}
