using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementMulti : NetworkBehaviour
{
    Joystick joystick;
    GameObject Boat;
    // Start is called before the first frame update
    public int moveSpeed;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        Boat = GetComponent<MovementMulti>().gameObject;
    }
    public override void OnStartLocalPlayer()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
    }

    void Move()
    {

        if (joystick.input.x > 0 || joystick.input.x < 0)
        {
            
            Boat.transform.position += new Vector3(joystick.input.x * (moveSpeed) * Time.deltaTime, 0f, 0f);
            CmdProvidePositiontoServer(Boat, Boat.transform.position);
            /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
            //print("X: " + joystick.input.x);
            // transform.rotation = new Quaternion(0, 0, 180 * joystick.input.x,0);
        }
        if (joystick.input.y > 0 || joystick.input.y < 0)
        {
            Boat.transform.position += new Vector3(0f, joystick.input.y * (moveSpeed) * Time.deltaTime, 0f);
            CmdProvidePositiontoServer(Boat, Boat.transform.position);
            /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
            //print("Y: " + joystick.input.y);
        }

    }

    [Command]
    void CmdProvidePositiontoServer(GameObject BBoat, Vector3 pos)
    {
        RpcTransmitplayerTransform(BBoat, pos);

    }

    [ClientRpc][ClientCallback]
    void RpcTransmitplayerTransform(GameObject BBoat, Vector3 pos)
    {
        BBoat.transform.position = pos;
    }
}
