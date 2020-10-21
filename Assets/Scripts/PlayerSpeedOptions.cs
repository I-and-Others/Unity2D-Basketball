using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSpeedOptions : MonoBehaviour
{
	private static float m_MySliderValue;
    public Slider playerSpeedSlider;
    public GameObject player;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
    	m_MySliderValue = playerSpeedSlider.value;
        PlayerController.movementSpeed = m_MySliderValue;
        speedText.text = m_MySliderValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    	m_MySliderValue = playerSpeedSlider.value;
    	PlayerController.movementSpeed = m_MySliderValue;
    	speedText.text = Mathf.RoundToInt(m_MySliderValue).ToString();
    }
}
