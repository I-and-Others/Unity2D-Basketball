﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
	public GameObject menuCanvas;
	public GameObject mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(){
    	mainCanvas.SetActive(true);
    	menuCanvas.SetActive(false);
    }

    public void QuitGame(){
    	Application.Quit();
    }
}