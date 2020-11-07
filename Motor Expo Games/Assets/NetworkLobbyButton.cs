using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Discovery;
using UnityEngine.UI;

public class NetworkLobbyButton : NetworkBehaviour
{
    NetworkRoomManager networkLobby;
    NetworkDiscovery networkDiscovery;
    NetworkManager networkManager;
    NetworkDiscoveryHUD networkDiscoveryHUD;
    public Text jionBtnText;

    [SerializeField]
    ServerResponse serverResponse;
    
    public bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        networkLobby = GameObject.FindObjectOfType<NetworkRoomManager>();
        networkDiscovery = FindObjectOfType<NetworkDiscovery>();
        networkManager = FindObjectOfType<NetworkManager>();
        networkDiscoveryHUD = FindObjectOfType<NetworkDiscoveryHUD>();
        InvokeRepeating("Discovery", 0, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        //networkDiscovery.StartDiscovery();
    }
    public void Host()
    {
        networkDiscoveryHUD.Host();
        isPressed = true;
    }
    public void Join()
    {
        if(networkDiscoveryHUD.discoveredServers.Count != 0)
        {
            networkManager.StartClient(serverResponse.uri);
            //networkDiscovery.AdvertiseServer();
            isPressed = true;

        }
        else
        {
            networkLobby.StartClient();
            isPressed = true;
        }
       
        
        
    }
    void Discovery()
    {
        networkDiscovery.StartDiscovery();
        print(networkDiscoveryHUD.discoveredServers.Count);
        foreach (ServerResponse info in networkDiscoveryHUD.discoveredServers.Values)
        {
            if (networkDiscoveryHUD.discoveredServers.Count > 0)
            {
                jionBtnText.color = Color.red;
                jionBtnText.text = info.EndPoint.Address.ToString();
            }
            print(info.EndPoint.Address.ToString());
            serverResponse = info;

        }



    }
}
