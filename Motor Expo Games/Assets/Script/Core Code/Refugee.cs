using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refugee : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField]
    Player1_Controller player;

    [Header("Refugee Parameter")]
    public float moveSpeed;
    [SerializeField]
    bool isPlayerAttacked;
    [SerializeField]
    bool playerCollideRescueBase;
    [SerializeField]
    bool moveWithPlayer;
    public float nearRadius;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller>();
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
        
    }
    private void LateUpdate()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void checkPlayerAttacked()
    {
        isPlayerAttacked = player.checkGetAttack();
    }

    public void checkPlayerCollideRescueBase()
    {
        playerCollideRescueBase = player.checkInRescue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moveWithPlayer = true;
            player.NumOfRescue += 1;
        }
        if(collision.tag == "PlayerBase")
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.point += 1;
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
            player.NumOfRescue -= 1;
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
}
