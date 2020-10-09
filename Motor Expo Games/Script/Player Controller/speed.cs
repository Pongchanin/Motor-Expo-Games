﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    private float timer;
    public float duration;
    public float speedbonus;
    GameObject playerhitted;
    private bool timerstart = false;
    private float playerspeed;
    float tempSpeed;
    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
        }

        if (timer == 0 && timerstart)
        {
            if(playerhitted != null)
            {
                if (playerhitted.GetComponent<Player1_Controller_Solo>() != null)
                {
                    playerhitted.GetComponent<Player1_Controller_Solo>().moveSpeed = playerspeed;
                }
                else
                {
                    playerhitted.GetComponent<Player1_Controller_Mult>().moveSpeed = playerspeed;
                }
                
                Destroy(this.gameObject);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerhitted = collision.gameObject;
            StartCoroutine(itemgetto());
        }
    }
    private IEnumerator itemgetto()
    {
        timer = duration;
        timerstart = true;
        if (playerhitted != null)
        {
            if (playerhitted.GetComponent<Player1_Controller_Solo>() != null)
            {
                playerspeed = playerhitted.GetComponent<Player1_Controller_Solo>().moveSpeed;
                playerhitted.GetComponent<Player1_Controller_Solo>().moveSpeed = speedbonus;
            }
            else
            {
                playerspeed = playerhitted.GetComponent<Player1_Controller_Mult>().moveSpeed;
                playerhitted.GetComponent<Player1_Controller_Mult>().moveSpeed = speedbonus;
            }
        }
        
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2.5f);
        if (playerhitted.GetComponent<Player1_Controller_Solo>() != null)
        {
            playerspeed = playerhitted.GetComponent<Player1_Controller_Solo>().moveSpeed;
            playerhitted.GetComponent<Player1_Controller_Solo>().moveSpeed = tempSpeed;
        }
        else
        {
            playerspeed = playerhitted.GetComponent<Player1_Controller_Mult>().moveSpeed;
            playerhitted.GetComponent<Player1_Controller_Mult>().moveSpeed =tempSpeed;
        }
    }
}
