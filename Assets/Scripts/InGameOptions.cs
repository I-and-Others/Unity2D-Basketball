using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameOptions : MonoBehaviour
{

    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    float m_MySliderValue;
    public Slider musicVolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_MyAudioSource.volume = musicVolumeSlider.value;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Resume()
    {
        Time.timeScale = 1;        
    }
    public void SettingsOn()
    {
        Time.timeScale = 0;

    }
}
