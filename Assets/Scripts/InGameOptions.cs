using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameOptions : MonoBehaviour
{
	
	
    public Slider playerSpeedSlider;
    public Text speedText;
    public GameObject[] inGameObjects;
    public GameObject inGameObject;
    public AudioSource mainMusic;
    public Sprite isJoystickOnSprite;
    public Sprite isJoystickOffSprite;
    public bool isJoystick;
    public GameObject joystick;
    public GameObject touchController;
    public GameObject player;
    public GameObject scoreText;
    public GameObject isJoystickButton;
    public Slider musicVolumeSlider;

    void Start()
    {
    	LoadSettings();
    	ControllerToggle();
    	FindInGameObjects();       
    }

    void Update()
    {    	
        
    }
    public void speedTextChange(){
    	speedText.text = Mathf.RoundToInt(playerSpeedSlider.value).ToString();
    }

    public void musicVolumeChange(){    	
       	mainMusic.volume = musicVolumeSlider.value;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Resume()
    {
        Time.timeScale = 1;
       	inGameObjectsOn();
       	ControllerToggle();
        SaveSettings();
        LoadSettings();
    }
    public void SettingsOn()
    {
        Time.timeScale = 0;
        FindInGameObjects();
        inGameObjectsOff();
    }

    public void ControllerToggle(){    	
    	if(isJoystick == false){
        	joystick.SetActive(false);
        	touchController.SetActive(true);
        	Image sprite = isJoystickButton.GetComponent<Image>();
        	sprite.sprite = isJoystickOffSprite;    	
        }
        else{
        	joystick.SetActive(true);
        	touchController.SetActive(false);
        	Image sprite = isJoystickButton.GetComponent<Image>();
        	sprite.sprite = isJoystickOnSprite;
        }
    }
    public void isJoystickToggler(){
    	isJoystick = !isJoystick;
    	ControllerToggle();
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

    public void FindInGameObjects(){    	
    	inGameObjects = GameObject.FindGameObjectsWithTag("InGameObjects");
    }

    public void LoadSettings(){
		GameData data = SaveSystem.LoadSettings();
		playerSpeedSlider.value = data.speedValue;
		musicVolumeSlider.value = data.musicValue;
		mainMusic.volume = musicVolumeSlider.value;
		isJoystick = data.isJoystick;
		PlayerController.movementSpeed = playerSpeedSlider.value;	
	}

	public void SaveSettings(){		
		SaveSystem.SaveData(this);
	}
}
