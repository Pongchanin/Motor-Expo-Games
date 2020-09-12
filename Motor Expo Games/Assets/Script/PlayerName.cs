using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
    /*void Awake()
    {
        if (boatstatus.thisisplayer == 1)
        {
            transform.name = "Player 1 Boat";
        }
        else if (boatstatus.thisisplayer == 2)
        {
            transform.name = "Player 2 Boat";
        }
        else if (boatstatus.thisisplayer == 3)
        {
            transform.name = "Player 3 Boat";
        }
        else if (boatstatus.thisisplayer == 4)
        {
            transform.name = "Player 4 Boat";
        }
    }
    */
    [SyncVar] public string playeruniqueIdentity;
    private NetworkInstanceId PlayernetIUD;
    private Transform mytransform;
    public PlayerColor[] Playercolor;

    public override void OnStartLocalPlayer()
    {
        Getnetidentity();
        setidentity();
    }

    void Awake()
    {
        mytransform = transform;
    }

    void Update()
    {
        if (mytransform.name == "" || mytransform.name == "Prototype Player(Clone)")
        {
            setidentity();
        }
        if (isLocalPlayer)
        {
            Playercolor = Resources.FindObjectsOfTypeAll<PlayerColor>();
            Playercolor[0].value = int.Parse(PlayernetIUD.ToString());
        }
    }

    [Client]
    void Getnetidentity()
    {
        PlayernetIUD = GetComponent<NetworkIdentity>().netId;
        CmdTellserverMyidentity(makeuniqueidentity());
        //boatstatus.Thisisplayer = int.Parse(PlayernetIUD.ToString());
    }

    void setidentity()
    {
        if (!isLocalPlayer)
        {
            mytransform.name = playeruniqueIdentity;
        }
        else
        {
            mytransform.name = makeuniqueidentity();
        }
    }

    string makeuniqueidentity()
    {
        string uniquename = "Player " + netId.ToString() + " Boat";
        return uniquename;
    }

    [Command]
    void CmdTellserverMyidentity(string name)
    {
        playeruniqueIdentity = name;
    }
}
