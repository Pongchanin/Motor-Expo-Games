using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{

   /* protected Joystick joystick;
    protected JoyButton joybutton;*/

    public float moveSpeed;


    Vector2 movement;

    private void Start()
    {
        /*joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f )
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f )
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }
       /* if (Mathf.Abs(Input.GetAxis("Joy" + i + "x") || Mathf.Abs(Input.GetAxis("Joy" + i + "y"))) 
        {
            Debug.Log(Input.GetJoystickNames()[i] + "is moved");
        }*/
    }
}


//Input.GetJoystickNames("Vertical") > 0.5f || Input.GetJoystickNames("Vertical") < -0.5f||Input.GetJoystickNames("horizontal") > 0.5f || Input.GetJoystickNames("Horizontal") < -0.5f//