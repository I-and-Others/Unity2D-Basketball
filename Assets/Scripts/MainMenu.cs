using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject panelGame;
	public GameObject panelMenu;
	public GameObject mainCamera;

	void Awake(){
		mainCamera.GetComponent<BallSpawner>().enabled = false;
	}

    public void PlayGame(){
    	//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    	//SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    	panelGame.SetActive(true);
    	panelMenu.SetActive(false);
    	mainCamera.GetComponent<BallSpawner>().enabled = true;
    }

    public void QuitGame(){
    	Application.Quit();
    }
}
