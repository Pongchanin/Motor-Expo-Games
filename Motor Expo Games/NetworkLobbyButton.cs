using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[System.Obsolete]
public class NetworkLobbyButton : NetworkBehaviour
{
    NetworkRoomManager networkLobby;
    public bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        networkLobby = GameObject.FindObjectOfType<NetworkRoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Host()
    {
        networkLobby.StartHost();
        isPressed = true;
    }
    public void Join()
    {
        networkLobby.StartClient();
        isPressed = true;
    }
}
