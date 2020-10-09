﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class NetworkPlayerManager : NetworkBehaviour
{
    [SerializeField]
    NetworkRoomManager networkLobby;
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
        networkLobby = GameObject.FindObjectOfType<NetworkRoomManager>();
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
            for (int i = 9; i < networkLobby.roomSlots.Count; i++)
            {
                print(networkLobby.roomSlots[i].index);
            }
            
        }



    }
    void UpdateStat()
    {
        if (networkLobby.roomSlots[0] != null)
        {
            networkLobby.roomSlots[0].gameObject.name = "Player 1";
            if (networkLobby.roomSlots[0].readyToBegin == false)
            {

                p1ready.text = "Not Ready";
            }
            else
            {
                p1ready.text = "Ready";
            }
            
            //print(networkLobby.roomSlots[0].netId);
        }
        else
        {
            p1ready.text = "Not Exist";
        }
        if (networkLobby.roomSlots[1] != null)
        {
            networkLobby.roomSlots[1].gameObject.name = "Player 2";
            if (networkLobby.roomSlots[1].readyToBegin == false)
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
        if (networkLobby.roomSlots[2] != null)
        {
            networkLobby.roomSlots[2].gameObject.name = "Player 3";
            if (networkLobby.roomSlots[2].readyToBegin == false)
            {
                p3ready.text = "Not Ready";
            }
            else
            {
                p3ready.text = "Ready";
            }
            print(networkLobby.roomSlots[2].netId);
        }
        else
        {
            p3ready.text = "Not Exist";
        }
        if (networkLobby.roomSlots[3] != null)
        {
            networkLobby.roomSlots[3].gameObject.name = "Player 4";
            if (networkLobby.roomSlots[3].readyToBegin == false)
            {
                p4ready.text = "Not Ready";
            }
            else
            {
                p4ready.text = "Ready";
            }
            print(networkLobby.roomSlots[3].netId);
        }
        else
        {
            p4ready.text = "Not Exist";
        }
    }

    public void Ready()
    {
        if (networkLobby.roomSlots[0].isLocalPlayer)
        {
            if(networkLobby.roomSlots[0].readyToBegin == false)
            {
                networkLobby.roomSlots[0].CmdChangeReadyState(true);
            }
            else
            {
                networkLobby.roomSlots[0].CmdChangeReadyState(false);
            }
            
        }

        else if (networkLobby.roomSlots[1].isLocalPlayer)
        {
            if (networkLobby.roomSlots[1].readyToBegin == false)
            {
                networkLobby.roomSlots[1].CmdChangeReadyState(true);
            }
            else
            {
                networkLobby.roomSlots[1].CmdChangeReadyState(false);
            }

        }
        else if (networkLobby.roomSlots[2].isLocalPlayer)
        {
            if (networkLobby.roomSlots[2].readyToBegin == false)
            {
                networkLobby.roomSlots[2].CmdChangeReadyState(true);
            }
            else
            {
                networkLobby.roomSlots[2].CmdChangeReadyState(false);
            }

        }
        else if (networkLobby.roomSlots[3].isLocalPlayer)
        {
            if (networkLobby.roomSlots[3].readyToBegin == false)
            {
                networkLobby.roomSlots[3].CmdChangeReadyState(true);
            }
            else
            {
                networkLobby.roomSlots[3].CmdChangeReadyState(false);
            }

        }
    }
}
