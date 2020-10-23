using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameOptions : MonoBehaviour
{
	private static float speedValue;
    public Slider playerSpeedSlider;
    public Text speedText;
    public GameObject[] inGameObjects;
    public GameObject inGameObject;
    public AudioSource m_MyAudioSource;
    public Sprite isJoystickOnSprite;
    public Sprite isJoystickOffSprite;
    public static bool isJoystick;
    public GameObject joystick;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject player;
    public GameObject scoreText;
    //Value from the slider, and it converts to volume level
    float m_MySliderValue;
    public Slider musicVolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
    	isJoystick = true;
    	inGameObjects = GameObject.FindGameObjectsWithTag("InGameObjects");
        speedValue = playerSpeedSlider.value;
        PlayerController.movementSpeed = speedValue;
        speedText.text = speedValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    	inGameObjects = GameObject.FindGameObjectsWithTag("InGameObjects");
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
        inGameObjectsOn();
        if(isJoystick == false){
        	Debug.Log("ifteki isJoystick değeri: "+isJoystick);
        	joystick.SetActive(false);
        	leftButton.SetActive(true);
        	rightButton.SetActive(true);
        	scoreText.SetActive(true);
        	player.SetActive(true);
        }
        else{
        	Debug.Log("elseteki isJoystick değeri: "+isJoystick);
        	joystick.SetActive(true);
        	leftButton.SetActive(false);
        	rightButton.SetActive(false);
        	scoreText.SetActive(true);
        	player.SetActive(true);
        }
                 
    }
    public void SettingsOn()
    {

        Time.timeScale = 0;
        inGameObjectsOff();
    }

    public void isJoystickCheck()
    {
    	if(isJoystick == true){
    		Image sprite = GameObject.Find("isJoystickButton").GetComponent<Image>();
        	sprite.sprite = isJoystickOffSprite;
        	isJoystick = false;
    	}
        else{
    		Image sprite = GameObject.Find("isJoystickButton").GetComponent<Image>();
        	sprite.sprite = isJoystickOnSprite;
        	isJoystick = true;    	
    	}
    }

    public void inGameObjectsOn(){
    	foreach (GameObject inGameObject in inGameObjects)
        {            
        	inGameObject.SetActive(true); 
        }    
    }

    public void inGameObjectsOff(){
    	foreach (GameObject inGameObject in inGameObjects)
        {            
        	inGameObject.SetActive(false); 
        }    
    }
}
