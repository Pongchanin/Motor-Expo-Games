using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Discovery;
[System.Obsolete]
public class NetworkLobbyButton : NetworkBehaviour
{
    NetworkRoomManager networkLobby;
    NetworkDiscovery networkDiscovery;
    NetworkManager networkManager;

    Dictionary<long, ServerResponse> discoveredServers = new Dictionary<long, ServerResponse>();
    public bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        networkLobby = GameObject.FindObjectOfType<NetworkRoomManager>();
        networkDiscovery = FindObjectOfType<NetworkDiscovery>();
        networkManager = FindObjectOfType<NetworkManager>();
        InvokeRepeating("Discovery", 0, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //networkDiscovery.StartDiscovery();
    }
    public void Host()
    {
        networkManager.StartHost();
        networkDiscovery.AdvertiseServer();
        isPressed = true;
    }
    public void Join()
    {
        if(discoveredServers.Count == 0)
        {
            networkManager.StartClient(discoveredServers[0].uri);
            networkDiscovery.AdvertiseServer();
            isPressed = true;
        }
       // networkLobby.StartClient();
        
        
    }
    void Discovery()
    {
        networkDiscovery.StartDiscovery();
        
        
    }
}
