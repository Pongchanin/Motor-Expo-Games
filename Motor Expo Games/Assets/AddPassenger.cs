using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AddPassenger : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Player1_Controller_Solo player1Solo;
    [SerializeField]
    Player1_Controller_Mult playerMult;
    [SerializeField]
    Player1_Controller_Mult[] players;
    [SerializeField]
    Player1_Controller_Mult[] temps = new Player1_Controller_Mult[4];
    GameObject temp;
    AudioSource audioSource;
    Vector2 center;
    [SerializeField]
    float circleRadius;

    void Start()
    {
        player1Solo = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        playerMult = NetworkBehaviour.FindObjectOfType<Player1_Controller_Mult>();
        temp = new GameObject();
        temp = gameObject;
        audioSource = GetComponent<AudioSource>();
        center = transform.position;
        FindCorrectPlayer();
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
        print("OnMouseDown:" + gameObject.name);

        CopyComp();

        //Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
      
    }
    [ClientRpc]
    void CopyComp()
    {
        if(player1Solo != null)
        {
            for (int i = 0; i < player1Solo.passenger.Length; i++)
            {
                print("Solo: " + i);
                if (player1Solo.passenger[i] == null)
                {
                    player1Solo.passenger[i] = temp;
                    audioSource.Play();
                    gameObject.SetActive(false);
                    break;
                }
                else if (player1Solo.passenger[i] != null)
                {
                    continue;
                }

                //Ignored
            }
        }
        else
        {
            print("NULL");
        }
    }
    [Command]
    void CopyCompMult()
    {
        print("Add me Up");
        for (int i = 0; i < playerMult.passenger.Length; i++)
        {
            print("Multi: " + i);
                if (playerMult.passenger[i] == null)
                {
                    playerMult.passenger[i] = temp;
                    audioSource.Play();
                    gameObject.SetActive(false);
                    break;
                }
                else if (playerMult.passenger[i] != null)
                {
                    continue;
                }

                //Ignored

        }
    }
    void OverlapCircle()
    {
        Collider2D temp = Physics2D.OverlapCircle(center, circleRadius);
        //print(temp.name);

        Collider2D[] temps = Physics2D.OverlapCircleAll(center, circleRadius);
        for(int i = 0; i < temps.Length; i++)
        {
          print(temps[i].name);
            if(temps[i].GetComponent<Player1_Controller_Solo>() != null)
            {
                CopyComp();

            }
            else if (temps[i].GetComponent<Player1_Controller_Mult>() != null)
            {
                CopyCompMult();
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);

    }
    [Command]
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
