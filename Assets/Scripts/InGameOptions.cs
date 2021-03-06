﻿using System.Collections;
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
    public int currentLevelIndex;
    public bool isMenu;
    public MainMenu mainMenu;
    void Start()
    {
    	//currentLevelIndex = SceneManager.GetActiveScene().buildIndex;    	
    	LoadSettings();	
    	if(currentLevelIndex != 0 && currentLevelIndex != SceneManager.GetActiveScene().buildIndex){
    		Application.LoadLevel(currentLevelIndex);
    	}    	
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
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
		if(data == null){
			playerSpeedSlider.value = 300;
			musicVolumeSlider.value = 0.5f;
			mainMusic.volume = musicVolumeSlider.value;
			isJoystick = true;
			PlayerController.movementSpeed = playerSpeedSlider.value;
			currentLevelIndex = 0;
		}
		else{
			playerSpeedSlider.value = data.speedValue;
			musicVolumeSlider.value = data.musicValue;
			mainMusic.volume = musicVolumeSlider.value;
			isJoystick = data.isJoystick;
			PlayerController.movementSpeed = playerSpeedSlider.value;
			currentLevelIndex = data.lastLevelIndex;
		}		
	}

	public void SaveSettings(){		
		SaveSystem.SaveData(this);
	}
}
