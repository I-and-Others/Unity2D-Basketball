using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartLevel : MonoBehaviour
{
    public Button restartButton;
    public int nextLevelIndex;
    public InGameOptions inGameOptions;
    public bool isMenu;

	void Start () {
		nextLevelIndex = inGameOptions.currentLevelIndex + 1;
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		inGameOptions.currentLevelIndex = inGameOptions.currentLevelIndex + 1;
		inGameOptions.SaveSettings();
		isMenu = false;
        SceneManager.LoadScene(nextLevelIndex, LoadSceneMode.Single);
	}
}
