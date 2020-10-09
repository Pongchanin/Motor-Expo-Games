using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class QTEMulti : NetworkBehaviour
{
    [SerializeField]
    GameObject temp;
    [SerializeField]
    Player1_Controller_Mult player;

    [SerializeField]
    Player1_Controller_Mult[] players;
    [SerializeField]
    Player1_Controller_Mult[] temps = new Player1_Controller_Mult[4];
    // Start is called before the first frame update
    [Client]
    void Start()
    {
            /*temp = GameObject.Find("Local");
            player = temp.GetComponent<Player1_Controller_Solo>();*/
    }

    // Update is called once per frame
    void Update()
    {
        FindCorrectPlayer();
    }
    public void QTEPressed()
    {
       player.QuickTimePressed();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        if (isLocalPlayer)
        {
            FindCorrectPlayer();
            player = temp.GetComponent<Player1_Controller_Mult>();
        }
        
    }

    [Client]
    void FindCorrectPlayer()
    {
        temps = NetworkBehaviour.FindObjectsOfType<Player1_Controller_Mult>();
        for (int i = 0; i < temps.Length; i++)
        {
            players[i] = temps[i];
            if (players[i].isLocalPlayer)
            {
                player = players[i];
            }
        }
    }
}
