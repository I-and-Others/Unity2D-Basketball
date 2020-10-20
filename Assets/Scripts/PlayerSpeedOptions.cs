using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSpeedOptions : MonoBehaviour
{
	private static float m_MySliderValue;
    public Slider playerSpeedSlider;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    	m_MySliderValue = playerSpeedSlider.value;
        PlayerController.movementSpeed = m_MySliderValue;
    }

    // Update is called once per frame
    void Update()
    {
    	m_MySliderValue = playerSpeedSlider.value;
    	PlayerController.movementSpeed = m_MySliderValue;
    }
}
