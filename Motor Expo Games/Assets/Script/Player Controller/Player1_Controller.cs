using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{

    protected Joystick joystick;
    protected JoyButton joybutton;


    public float moveSpeed;


    Vector2 movement;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.input.x > 0 ||joystick.input.x < 0  )
        {
            transform.Translate(new Vector3(joystick.input.x * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (joystick.input.y > 0 || joystick.input.y < 0)
        {
            transform.Translate(new Vector3(0f, joystick.input.y * moveSpeed * Time.deltaTime, 0f));
        }
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
           transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }
    }
}


