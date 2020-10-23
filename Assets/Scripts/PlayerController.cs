using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public VariableJoystick variableJoystick;
	[SerializeField] public static float movementSpeed;
	//[SerializeField] private Animator anim;
	private Vector2 movementDirection;
	private Rigidbody2D rb;
    public InGameOptions InGameOptions;
    [SerializeField] public static bool isJoystick;
    // Start is called before the first frame update
    void Start()
    {
        isJoystick = InGameOptions.isJoystick;
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        isJoystick = InGameOptions.isJoystick;
        processDirection();
        //processAnimation();
        
    }

    private void FixedUpdate(){
    	move();
    }

    private void processDirection(){
        if(isJoystick){ 
            movementDirection = new Vector2(variableJoystick.Horizontal,variableJoystick.Vertical);
        }
        else{
            movementDirection = new Vector2(ButtonController.direction,variableJoystick.Vertical);
        }
    }

    private void move(){
    	rb.velocity = movementDirection.normalized * movementSpeed * Time.deltaTime;
    }

    /*private void processAnimation(){
    	anim.SetFloat("Horizontal", movementDirection.x);
    	anim.SetFloat("Vertical", movementDirection.y);
    }*/

    #region ---------- Test TouchController ----------
    





    

    #endregion
}
