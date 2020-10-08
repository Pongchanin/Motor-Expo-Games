using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

[System.Obsolete]
public class CustomNetwork : NetworkManager     //
{
    public void StartupHost()
    {
        NetworkManager.singleton.StartHost();
    }
    public void JoinGame()
    {
        SetIPAddress();
        NetworkManager.singleton.StartClient();
    }

    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }
}
