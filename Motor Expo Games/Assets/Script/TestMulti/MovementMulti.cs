using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementMulti : NetworkBehaviour
{
    Joystick joystick;
    // Start is called before the first frame update
    public int moveSpeed;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }
    public override void OnStartLocalPlayer()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    [ServerCallback][ClientCallback]
    void Update()
    {
        if (isLocalPlayer && isClient)
        {
            if ((joystick.input.x > 0 || joystick.input.x < 0))
            {
                transform.Translate(new Vector3(joystick.input.x * (moveSpeed) * Time.deltaTime, 0f, 0f));

                /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
                //print("X: " + joystick.input.x);
                // transform.rotation = new Quaternion(0, 0, 180 * joystick.input.x,0);
            }
            if ((joystick.input.y > 0 || joystick.input.y < 0))
            {
                transform.Translate(new Vector3(0f, joystick.input.y * (moveSpeed) * Time.deltaTime, 0f));

                /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
                //print("Y: " + joystick.input.y);
            }
        }
        
    }
}
