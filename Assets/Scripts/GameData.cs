using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

	public float speedValue;
	public float musicValue;
	public bool isJoystick;
	public int lastLevelIndex;
	public bool isMenu;

	public GameData(InGameOptions inGameSettings){
		speedValue = inGameSettings.playerSpeedSlider.value;
		musicValue = inGameSettings.musicVolumeSlider.value;
		isJoystick = inGameSettings.isJoystick;
		lastLevelIndex = inGameSettings.currentLevelIndex;
		isMenu = inGameSettings.isMenu;
	}
}
