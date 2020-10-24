using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

	public float speedValue;
	public float musicValue;
	public bool isJoystick;


	public GameData(InGameOptions inGameSettings){
		speedValue = inGameSettings.speedValue;
		musicValue = inGameSettings.musicValue;
		isJoystick = inGameSettings.isJoystick;
	}


    
}
