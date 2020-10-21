using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameOptions : MonoBehaviour
{
	private static float speedValue;
    public Slider playerSpeedSlider;
    public GameObject player;
    public Text speedText;
    // Start is called before the first frame update
    







    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    float m_MySliderValue;
    public Slider musicVolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        speedValue = playerSpeedSlider.value;
        PlayerController.movementSpeed = speedValue;
        speedText.text = speedValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    	speedValue = playerSpeedSlider.value;
    	PlayerController.movementSpeed = speedValue;
    	speedText.text = Mathf.RoundToInt(speedValue).ToString();
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
