using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    float m_MySliderValue;
    public Slider musicVolumeSlider;

    void Update()
    {
    	m_MyAudioSource.volume = musicVolumeSlider.value;
        //Displays the value of the slider in the console.
        Debug.Log(musicVolumeSlider.value);
    }
}
