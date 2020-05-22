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
    bool followPlayer;
    public int stopPos;
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
        moveToPlayer();
    }

    public void checkPlayerAttacked()
    {
        isPlayerAttacked = player.checkGetAttack();
    }

    public void checkPlayerCollideRescueBase()
    {
        playerCollideRescueBase = player.checkInRescue();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       /* if (collision.tag == "Player")
        {
            if (player.checkInRescue())
            {
                this.gameObject.transform.LookAt(collision.transform.position);
                if (Vector2.Distance(transform
                    .position, collision.transform.position) > 1f)
                {
                    transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
                }
                followPlayer = true;
            }
        }*/
    }
    public void moveToPlayer()
    {
        if (player.checkInRescue() || followPlayer == true)
        {
            gameObject.transform.LookAt(player.transform.position);
            if (Vector2.Distance(transform.position, player.transform.position) > stopPos)
            {
                //transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0));
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.EulerAngles(0, 0, 0);
            }
        }
    }
    public bool getFollowPlayer()
    {
        return followPlayer;
    }
}
