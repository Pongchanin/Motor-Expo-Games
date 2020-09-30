﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockController : MonoBehaviour
{
    [Header("GameObject Parameter")]
    GameObject dock;
    [SerializeField]
    Player1_Controller_Solo player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        dock = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        print("OnMouseDown: " + gameObject.name);
        print(dock.tag);
        returnRefugee();
    }

    void returnRefugee()
    {
        for(int i = 0; i < player.passenger.Length; i++)
        {
            if(player.passenger[i] != null)
            {
                print(player.passenger[i].GetComponent<Refugee>().dest);
                if (dock.CompareTag("dest1") && player.passenger[i].GetComponent<Refugee>().dest == 0)
                {
                    GameManager gm = GameObject.FindObjectOfType<GameManager>();
                    gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                    Destroy(player.passenger[i]);
                }
                else if (dock.CompareTag("dest2") && player.passenger[i].GetComponent<Refugee>().dest == 1)
                {
                    GameManager gm = GameObject.FindObjectOfType<GameManager>();
                    gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                    Destroy(player.passenger[i]);
                }
                else if (dock.CompareTag("dest3") && player.passenger[i].GetComponent<Refugee>().dest == 2)
                {
                    GameManager gm = GameObject.FindObjectOfType<GameManager>();
                    gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                    Destroy(player.passenger[i]);
                }
                else if (dock.CompareTag("dest4") && player.passenger[i].GetComponent<Refugee>().dest == 3)
                {
                    GameManager gm = GameObject.FindObjectOfType<GameManager>();
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
}
