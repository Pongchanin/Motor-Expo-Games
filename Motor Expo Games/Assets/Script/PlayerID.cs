using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerID : NetworkBehaviour
{
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
        if(mytransform.name == "" || mytransform.name == "lobbyplayer(Clone)")
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
        string uniquename = "Player " + PlayernetIUD.ToString();
        return uniquename;
    }

    [Command]
    void CmdTellserverMyidentity(string name)
    {
        playeruniqueIdentity = name;
    }
    
    //Player 1

}
