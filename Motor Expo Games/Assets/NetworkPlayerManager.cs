using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkPlayerManager : NetworkBehaviour
{
    [SerializeField]
    NetworkLobbyManager networkLobby;
    [SerializeField]
    NetworkLobbyButton lobbyButton;

    [SerializeField]
    int numOfPlayer;

    [SerializeField]
    Text p1ready, p2ready, p3ready, p4ready;

    [SerializeField]
    bool isPressedNetwork;

    [SerializeField]
    GameObject buttonCanvas, networkCanvas;
    // Start is called before the first frame update
    void Start()
    {
        networkLobby = GameObject.FindObjectOfType<NetworkLobbyManager>();
        lobbyButton = GameManager.FindObjectOfType<NetworkLobbyButton>();
        isPressedNetwork = false;
        networkCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        numOfPlayer = networkLobby.numPlayers;
        isPressedNetwork = lobbyButton.isPressed;
        if(isPressedNetwork == true)
        {
            networkCanvas.SetActive(true);
            buttonCanvas.SetActive(false);
            UpdateStat();
        }



    }
    void UpdateStat()
    {
        if (networkLobby.lobbySlots[0] != null)
        {
            if (networkLobby.lobbySlots[0].readyToBegin == false)
            {
                p1ready.text = "Not Ready";
            }
            else
            {
                p1ready.text = "Ready";
            }
            
            //print(networkLobby.lobbySlots[0].netId);
        }
        else
        {
            p1ready.text = "Not Exist";
        }
        if (networkLobby.lobbySlots[1] != null)
        {
            if (networkLobby.lobbySlots[1].readyToBegin == false)
            {
                p2ready.text = "Not Ready";
            }
            else
            {
                p2ready.text = "Ready";
            }
        }
        else
        {
            p2ready.text = "Not Exist";
        }
        if (networkLobby.lobbySlots[2] != null)
        {
            if (networkLobby.lobbySlots[2].readyToBegin == false)
            {
                p3ready.text = "Not Ready";
            }
            else
            {
                p3ready.text = "Ready";
            }
            print(networkLobby.lobbySlots[2].netId);
        }
        else
        {
            p3ready.text = "Not Exist";
        }
        if (networkLobby.lobbySlots[3] != null)
        {
            if (networkLobby.lobbySlots[3].readyToBegin == false)
            {
                p4ready.text = "Not Ready";
            }
            else
            {
                p4ready.text = "Ready";
            }
            print(networkLobby.lobbySlots[3].netId);
        }
        else
        {
            p4ready.text = "Not Exist";
        }
    }

    public void Ready()
    {
        if (networkLobby.lobbySlots[0].isLocalPlayer)
        {
            if(networkLobby.lobbySlots[0].readyToBegin == false)
            {
                networkLobby.lobbySlots[0].SendReadyToBeginMessage();
            }
            else
            {
                networkLobby.lobbySlots[0].SendNotReadyToBeginMessage();
            }
            
        }

        else if (networkLobby.lobbySlots[1].isLocalPlayer)
        {
            if (networkLobby.lobbySlots[1].readyToBegin == false)
            {
                networkLobby.lobbySlots[1].SendReadyToBeginMessage();
            }
            else
            {
                networkLobby.lobbySlots[1].SendNotReadyToBeginMessage();
            }

        }
        else if (networkLobby.lobbySlots[2].isLocalPlayer)
        {
            if (networkLobby.lobbySlots[2].readyToBegin == false)
            {
                networkLobby.lobbySlots[2].SendReadyToBeginMessage();
            }
            else
            {
                networkLobby.lobbySlots[2].SendNotReadyToBeginMessage();
            }

        }
        else if (networkLobby.lobbySlots[3].isLocalPlayer)
        {
            if (networkLobby.lobbySlots[3].readyToBegin == false)
            {
                networkLobby.lobbySlots[3].SendReadyToBeginMessage();
            }
            else
            {
                networkLobby.lobbySlots[3].SendNotReadyToBeginMessage();
            }

        }
    }
}
