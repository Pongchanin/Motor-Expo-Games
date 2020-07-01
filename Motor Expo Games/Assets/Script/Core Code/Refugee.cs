using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum Type
{
    Normal, Hurry, Traveler
}
public class Refugee : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField]
    Player1_Controller player;
    public Type type;  

    [Header("Refugee Parameter")]
    public float moveSpeed;
    [SerializeField]
    bool isPlayerAttacked;
    [SerializeField]
    bool playerCollideRescueBase;
    public bool moveWithPlayer;
    public float nearRadius;
    [SerializeField]
    string RefugeeType;
    [SerializeField]
    int scoreVal;
    public float waitTimer;
    [SerializeField]
    bool timerRunning;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller>();
        checkRefugeeType();
        setRefugeeType();
        timerRunning = true;
    }


    // Update is called once per frame
    void Update()
    {
        checkPlayerAttacked();
        checkPlayerCollideRescueBase();
        if (moveWithPlayer)
        {
            moveToPlayer();
        }
        setRefugeeType();
        TimeCountDown();
        
    }
    private void LateUpdate()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void checkPlayerAttacked()
    {
        if(player != null)
        {
            isPlayerAttacked = player.checkGetAttack();
        }
    }

    public void checkPlayerCollideRescueBase()
    {
        if (player != null)
        {
            playerCollideRescueBase = player.checkInRescue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moveWithPlayer = true;
        }
        if(collision.tag == "PlayerBase")
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.point += scoreVal;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moveWithPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moveWithPlayer = false;
        }
    }
    public void moveToPlayer()
    {
            gameObject.transform.LookAt(player.transform.position);
            if(Vector2.Distance(transform.position,player.transform.position) > 1f)
            {
            // transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            transform.position = Vector3.Lerp(transform.position, player.transform.position, .15f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            }
       
    }
    public string checkRefugeeType()
    {
        return RefugeeType;
    }

    public void setRefugeeType()
    {
        RefugeeType = type.ToString();
        if(type.ToString() == "Normal")
        {
            scoreVal = 1;
        }
        else if(type.ToString() == "Hurry")
        {
            scoreVal = 2;
        }
        else
        {
            scoreVal = 5;
        }
    }
    void TimeCountDown()
    {
        if (timerRunning)
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                timerRunning = false;
            }
        }
    }
}
