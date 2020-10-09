using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum Type
{
    Normal, Hurry, Traveler
}
public class Refugee : NetworkBehaviour
{
    [Header("Player Reference")]
    [SerializeField]
    Player1_Controller_Mult player;
    Player1_Controller_Solo playerSolo;
    [SerializeField]
    Player1_Controller_Mult[] players;
    [SerializeField]
    Player1_Controller_Mult[] temps = new Player1_Controller_Mult[4];

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
    public int scoreVal;
    public float waitTimer;
    [SerializeField]
    bool timerRunning;
    [SerializeField]
    public int dest;
    bool isStun = false;
    public Animator bubble;
    // Start is called before the first frame update
    void Start()
    {
        if(NetworkBehaviour.FindObjectOfType<Player1_Controller_Mult>() != null)
        {
            player = NetworkBehaviour.FindObjectOfType<Player1_Controller_Mult>();
        }
        else
        {
            player = null;
            playerSolo = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        }
        
        checkRefugeeType();
        setRefugeeType();
        timerRunning = true;
        dest = (int)Random.Range(0,  4);
        animate();
        FindCorrectPlayer();


    }


    // Update is called once per frame
    void Update()
    {
        checkPlayerAttacked();
        checkPlayerCollideRescueBase();
        /*if (moveWithPlayer)
        {
            moveToPlayer();
        }*/
        setRefugeeType();
        TimeCountDown();
        setSprite();
        FindCorrectPlayer();
    }
    private void LateUpdate()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        if (moveWithPlayer)
        {
            moveToPlayer();
        }
    }
    public void checkPlayerAttacked()
    {
        if(player != null)
        {
            isPlayerAttacked = player.checkGetAttack();
        }
        else
        {
            isPlayerAttacked = playerSolo.checkGetAttack();
        }
    }

    public void checkPlayerCollideRescueBase()
    {
        if (player != null)
        {
            playerCollideRescueBase = player.checkInRescue();
        }
        else
        {
            playerCollideRescueBase = playerSolo.checkInRescue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*print("hit");

        if (collision.CompareTag("Player"))
        {
           // moveWithPlayer = true;
        }

        if(collision.CompareTag("dest1") && dest == 0)
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.point += scoreVal;
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("dest2") && dest == 1)
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.point += scoreVal;
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("dest3") && dest == 2)
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.point += scoreVal;
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("dest4") && dest == 3)
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.point += scoreVal;
            Destroy(this.gameObject);
        }*/
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       /* if (collision.CompareTag("Player"))
        {
            if (!isStun)
            {
                moveWithPlayer = true;
            }
            else
            {
                moveWithPlayer = false;
            }
            
        }*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Player"))
        {
            moveWithPlayer = false;
        }*/
    }
    public void moveToPlayer()
    {
        if(player != null)
        {
            gameObject.transform.LookAt(player.transform.position);
            if (Vector2.Distance(transform.position, player.transform.position) > 1f)
            {
                // transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
                transform.position = player.transform.position;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        else
        {
            gameObject.transform.LookAt(playerSolo.transform.position);
            if (Vector2.Distance(transform.position, playerSolo.transform.position) > 1f)
            {
                // transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
                transform.position = playerSolo.transform.position;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
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
            if(player != null)
            {
                scoreVal = (int)(1 * player.scoreMultiplier);
            }
            else
            {
                scoreVal = (int)(1 * playerSolo.scoreMultiplier);
            }
            
        }
        else if(type.ToString() == "Hurry")
        {
            if (player != null)
            {
                scoreVal = (int)(2 * player.scoreMultiplier);
            }
            else
            {
                scoreVal = (int)(2 * playerSolo.scoreMultiplier);
            }
        }
        else
        {
            if (player != null)
            {
                scoreVal = (int)(5 * player.scoreMultiplier);
            }
            else
            {
                scoreVal = (int)(5 * playerSolo.scoreMultiplier);
            }
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

    void animate()
    {
        Animator animate = gameObject.GetComponent<Animator>();

        if (RefugeeType == "Hurry")
        {
            animate.SetInteger("type", 1);
        }
        else if (RefugeeType == "Normal")
        {
            animate.SetInteger("type", 2);
        }
        else if (RefugeeType == "Traveler")
        {
            animate.SetInteger("type", 3);
        }

        bubble.SetInteger("DestAnim", dest + 1);

    }
    public void setSprite()
    {
        if (!moveWithPlayer)
        {
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            var color = GetComponent<SpriteRenderer>().color;
            color.a = 1;
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].color = color;
            }

            
        }

        else
        {
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            var color = GetComponent<SpriteRenderer>().color;
            color.a = 0;
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].color = color;
            }
        }
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
                player = players[i];
            }
        }
    }
}
