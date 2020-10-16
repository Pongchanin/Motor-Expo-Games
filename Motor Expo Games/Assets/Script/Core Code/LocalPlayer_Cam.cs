using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LocalPlayer_Cam : NetworkBehaviour
{
    [SerializeField]
    GameObject localPlayer;
    public Vector3 offset;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    Player1_Controller_Mult[] players;
    Player1_Controller_Mult[] temp = new Player1_Controller_Mult[4];
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (localPlayer != null)
        {
            cameraTransform.parent = localPlayer.transform;  //Make the camera a child of the mount point
            cameraTransform.position = localPlayer.transform.position + offset;  //Set position/rotation same as the mount point
            cameraTransform.rotation = localPlayer.transform.rotation;
        }
        FindCorrectPlayer();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

       
    }

    [Client]
    void FindCorrectPlayer()
    {
        temp = NetworkBehaviour.FindObjectsOfType<Player1_Controller_Mult>();
        for (int i = 0; i < temp.Length; i++)
        {
            players[i] = temp[i];
            if (players[i].isLocalPlayer)
            {
                localPlayer = players[i].gameObject;
            }
        }
    }
}
