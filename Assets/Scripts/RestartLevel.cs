using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartLevel : MonoBehaviour
{
    public Button restartButton;
    public int nextLevelIndex;
    public InGameOptions inGameOptions;

	void Start () {
		nextLevelIndex = inGameOptions.currentLevelIndex + 1;
		Debug.Log("nextLevelIndex: " + nextLevelIndex);
		Debug.Log("currentLevelIndex: " + inGameOptions.currentLevelIndex);
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		inGameOptions.currentLevelIndex = inGameOptions.currentLevelIndex + 1;
		inGameOptions.SaveSettings();
		Debug.Log(inGameOptions.currentLevelIndex + " indexi kaydedildi");
        SceneManager.LoadScene(nextLevelIndex, LoadSceneMode.Single);
	}
}
