using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DockController : NetworkBehaviour
{
    [Header("GameObject Parameter")]
    GameObject dock;
    [SerializeField]
    Player1_Controller_Solo player;
    [SerializeField]
    Player1_Controller_Mult playerMult;

    [SerializeField]
    Player1_Controller_Mult[] players;
    [SerializeField]
    Player1_Controller_Mult[] temps = new Player1_Controller_Mult[4];
    [SerializeField]
    GameManager gm;

    Vector2 center;
    [SerializeField]
    float circleRadius;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        if(player == null)
        {
            FindCorrectPlayer();
           playerMult = NetworkBehaviour.FindObjectOfType<Player1_Controller_Mult>();
        }
        dock = this.gameObject;
        gm  = GameObject.FindObjectOfType<GameManager>();
        center = transform.position;
    }

    // Update is called once per frame
    [Command]
    void Update()
    {
        OverlapCircle();
        FindCorrectPlayer();
    }

    private void OnMouseDown()
    {
        print("OnMouseDown: " + gameObject.name);
        print(dock.tag);
        returnRefugee();
    }
    [ClientRpc]
    void returnRefugee()
    {
        if(player != null)
        {
            for (int i = 0; i < player.passenger.Length; i++)
            {
                if (player.passenger[i] != null)
                {
                    print(player.passenger[i].GetComponent<Refugee>().dest);
                    if (dock.CompareTag("dest1") && player.passenger[i].GetComponent<Refugee>().dest == 0)
                    {
                        gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(player.passenger[i]);
                    }
                    else if (dock.CompareTag("dest2") && player.passenger[i].GetComponent<Refugee>().dest == 1)
                    {
                        gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(player.passenger[i]);
                    }
                    else if (dock.CompareTag("dest3") && player.passenger[i].GetComponent<Refugee>().dest == 2)
                    {
                        gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(player.passenger[i]);
                    }
                    else if (dock.CompareTag("dest4") && player.passenger[i].GetComponent<Refugee>().dest == 3)
                    {
                        gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(player.passenger[i]);
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        else
        {
            for (int i = 0; i < playerMult.passenger.Length; i++)
            {
                if (playerMult.passenger[i] != null)
                {
                    print(playerMult.passenger[i].GetComponent<Refugee>().dest);
                    if (dock.CompareTag("dest1") && playerMult.passenger[i].GetComponent<Refugee>().dest == 0)
                    {
                        gm.point += playerMult.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(playerMult.passenger[i]);
                    }
                    else if (dock.CompareTag("dest2") && playerMult.passenger[i].GetComponent<Refugee>().dest == 1)
                    {
                        gm.point += playerMult.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(playerMult.passenger[i]);
                    }
                    else if (dock.CompareTag("dest3") && playerMult.passenger[i].GetComponent<Refugee>().dest == 2)
                    {
                        gm.point += playerMult.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(playerMult.passenger[i]);
                    }
                    else if (dock.CompareTag("dest4") && playerMult.passenger[i].GetComponent<Refugee>().dest == 3)
                    {
                        gm.point += playerMult.passenger[i].GetComponent<Refugee>().scoreVal;
                        Destroy(playerMult.passenger[i]);
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        

    }
    void OverlapCircle()
    {
        FindCorrectPlayer();
        Collider2D cir = Physics2D.OverlapCircle(center, circleRadius);
        print(cir.name);

        Collider2D[] cirs = Physics2D.OverlapCircleAll(center, circleRadius);
        for (int i = 0; i < cirs.Length; i++)
        {
            print(cirs[i].name);
            if (cirs[i].GetComponent<Player1_Controller_Solo>() != null)
            {
                returnRefugee();
            }
            else if (cirs[i].GetComponent<Player1_Controller_Mult>() != null)
            {
                returnRefugee();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);

    }

    [ClientRpc]
    void FindCorrectPlayer()
    {
        temps = NetworkBehaviour.FindObjectsOfType<Player1_Controller_Mult>();
        for (int i = 0; i < temps.Length; i++)
        {
            players[i] = temps[i];
            if (players[i].isLocalPlayer)
            {
                playerMult = players[i];
            }
        }
    }
}
