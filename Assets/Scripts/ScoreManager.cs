using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score;
    public Text ScoreText;
    public AudioSource basketSesi;
    public GameObject restartButton;
    void Start()
    {
        basketSesi = GetComponent<AudioSource> ();
    }
    // Update is called once per frame
    void Update(){
        if(Score >= 5){
            YouWin();
        }
        
    }
    void YouWin(){
        ScoreText.text = "You Win!";
        Time.timeScale = 0f;
        restartButton.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag =="Ball"){
			Destroy(other.gameObject);
			AddScore();
        }        
    }

    void AddScore(){
        Score++;
        ScoreText.text = Score.ToString();
        basketSesi.Play();
    }
}
