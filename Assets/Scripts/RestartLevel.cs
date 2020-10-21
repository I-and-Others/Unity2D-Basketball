using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartLevel : MonoBehaviour
{
    public Button restartButton;

	void Start () {
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

	}
}
