using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameOptions : MonoBehaviour
{
	public float speedValue = 100f;
	public float musicValue = 80f;
    public Slider playerSpeedSlider;
    public Text speedText;
    public GameObject[] inGameObjects;
    public GameObject inGameObject;
    public AudioSource m_MyAudioSource;
    public Sprite isJoystickOnSprite;
    public Sprite isJoystickOffSprite;
    public  bool isJoystick = true;
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
    	LoadSettings();
    	//speedValue value burada değişirse bütün oyunda değişir

    	//isJoystick = true;
    	inGameObjects = GameObject.FindGameObjectsWithTag("InGameObjects");
        playerSpeedSlider.value = speedValue;
        PlayerController.movementSpeed = speedValue;
        speedText.text = speedValue.ToString();
        musicVolumeSlider.value = musicValue;
        m_MyAudioSource.volume = musicVolumeSlider.value;

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
        	joystick.SetActive(false);
        	leftButton.SetActive(true);
        	rightButton.SetActive(true);
        	scoreText.SetActive(true);
        	player.SetActive(true);
        }
        else{
        	joystick.SetActive(true);
        	leftButton.SetActive(false);
        	rightButton.SetActive(false);
        	scoreText.SetActive(true);
        	player.SetActive(true);
        }
        SaveSettings();
        Debug.Log("Ayarlardan çıkıldı.");
        LoadSettings();
        Debug.Log("Kaydedilen ayarlar uygulandı.");

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

    public void LoadSettings(){
		GameData data = SaveSystem.LoadSettings();
		speedValue = data.speedValue;
		musicValue = data.musicValue;
		isJoystick = data.isJoystick;
		Debug.Log("Ayarlar yüklendi hacım.");
	}
	public void SaveSettings(){
		SaveSystem.SaveData(this);
		Debug.Log("Settings kaydedildi hacım.");
	}
}
