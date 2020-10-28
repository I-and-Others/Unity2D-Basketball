using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public bool buttonPressed;
	public static float direction;
	public Button button;
    public void OnPointerDown(PointerEventData eventData){
    	button = GetComponent<Button>();
    	if(button.name == "LeftButton"){
    		direction = -1.0f;
    	}
    	if(button.name == "RightButton"){
    		direction = 1.0f;
    	}
        buttonPressed = true;        
    }
     
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
        direction = 0f;        
    }    
}
