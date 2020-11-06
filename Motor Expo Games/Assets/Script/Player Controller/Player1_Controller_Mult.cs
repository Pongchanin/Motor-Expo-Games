using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player1_Controller_Mult : NetworkBehaviour
{

    protected Joystick joystick;
    protected JoyButton joybutton;

    [Header("Player Parameter")] 
    [SyncVar]public float moveSpeed;
    [SyncVar] public float stunDuration;
    [SyncVar] public float scoreMultiplier;

    [Header("Condition Checker")]
    [SerializeField]
    private bool getAttack;
    [SerializeField]
    private bool inRescue;
    [SerializeField]
    private bool isStun;
    [SerializeField]
    private bool atBase;
    public int NumOfRescue;
    /*
    [SerializeField]
    int picIndex;
    [SyncVar] public Sprite[] boatPics;
    [SerializeField]
    [SyncVar] GameObject currentSprite;
    [SerializeField]
    [SyncVar] public Sprite boatSprite;
    */
    Vector2 movement;

    //----------------------
    [SerializeField]
    private bool QTE = false;
    private bool result_pass = true;
    public bool noquicktime = false;
    public Bar bar;
    public ArrowObj arrow;
    //public Press press;
    public GameObject sprite;

    Bar[] bars;
    ArrowObj[] arrows;
    Press[] presses;

    //public GameObject waveSprite;

    bool quickTimePressed;

    [Header("Boat Parameter")]
    public GameObject[] passenger;
    public int numOfPassenger;

    [Header("Sprite Parameter")]
    [SyncVar] public Transform[] seats;
    public GameObject[] occupiedSeat;
    public Sprite normal,hurry,traveler;


    void Start()
    {
        Application.targetFrameRate = 120;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
        bar = NetworkBehaviour.FindObjectOfType<Bar>();
        arrow = NetworkBehaviour.FindObjectOfType<ArrowObj>();
        //press = NetworkBehaviour.FindObjectOfType<Press>();

        moveSpeed = boatstatus.Player1.movementspeed * 3;
        //picIndex = PlayerPrefs.GetInt("BoatPic");
        //currentSprite = sprite;
        //boatSprite = currentSprite.GetComponentInChildren<SpriteRenderer>().sprite;


        if (bar != null)
        {
            bar.gameObject.SetActive(false);
        }
        if(arrow != null)
        {
            arrow.gameObject.SetActive(false);
        }
        /*if(press != null)
        {
            press.gameObject.SetActive(false);
        }*/
        if(moveSpeed == 0)
        {
            moveSpeed = 10;
        }
    }

    // Update is called once per frame
    [ClientRpc]
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
            //boatSprite = boatPics[picIndex];
            if ((joystick.input.x > 0 || joystick.input.x < 0) && isStun != true && !QTE)
            {
                transform.Translate(new Vector3(joystick.input.x * (moveSpeed) * Time.deltaTime, 0f, 0f));

                /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
                //print("X: " + joystick.input.x);
                // transform.rotation = new Quaternion(0, 0, 180 * joystick.input.x,0);
            }
            if ((joystick.input.y > 0 || joystick.input.y < 0) && isStun != true && !QTE)
            {
                transform.Translate(new Vector3(0f, joystick.input.y * (moveSpeed) * Time.deltaTime, 0f));

                /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
                //print("Y: " + joystick.input.y);
            }

            if ((Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) && isStun != true && !QTE)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * (moveSpeed) * Time.deltaTime, 0f, 0f));
                //print("X: " + Input.GetAxisRaw("Horizontal"));
            }
            if ((Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) && isStun != true && !QTE)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * (moveSpeed) * Time.deltaTime, 0f));
                //print("Y: " + Input.GetAxisRaw("Vertical"));
            }
            if (!result_pass)
            {
                setStun(true);
                Invoke("ResetStun", stunDuration);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                QTE = true;
            }

            quicktimeevent();
            turnSprite();
            //SetSprite();
    }
        
    [Command]
    public bool checkGetAttack()
    {
       return getAttack;
    }
    [Command]
    public void setGetAttack(bool val)
    {
        getAttack = val;
    }
    
    public bool checkInRescue()
    {
        return inRescue;
    }
    public void setInRescue(bool val)
    {
        inRescue = val;
    }

    [Command]
    public bool getIsStun()
    {
        return isStun;
    }
    [Command]
    public void setStun(bool val)
    {
        isStun = val;
    }

    public bool getIsBase()
    {
        return atBase;
    }
    public void setAtBase(bool val)
    {
        atBase = val;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("RescuePlace"))
        {
            //print("RescuePlace collide");
            setInRescue(true);
        }

        if(collision.CompareTag("PlayerBase"))
        {
            //print("At Player Base");
            setAtBase(true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        Collider2D[] refugees = Physics2D.OverlapCircleAll(transform.position, 5f);
        for (int i = 0; i < refugees.Length; i++)
        {
            if (refugees[i].tag == "RescuePeople")
            {
                Refugee temp = refugees[i].GetComponent<Refugee>();
                //passenger[i-1] = refugees[i].gameObject;
                if (temp.moveWithPlayer)
                {
                    NumOfRescue += 1;
                }
            }
            numOfPassenger = refugees.Length;
        }*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       /* if(collision.CompareTag("RescuePlace"))
        {
            print("Exit from RescuePlace");
            setInRescue(false);
        }
        
        if (collision.CompareTag("PlayerBase"))
        {
            print("Exit Player Base");
            setAtBase(false);
        }
        Collider2D[] refugees = Physics2D.OverlapCircleAll(transform.position, 5f);
        for (int i = 0; i < refugees.Length; i++)
        {
            if (refugees[i].tag == "RescuePeople")
            {
                Refugee temp = refugees[i].GetComponent<Refugee>();
               // passenger[i - 1] = null;
                if (temp.moveWithPlayer)
                {
                    NumOfRescue -= 1;
                }
            }
        }*/
    }

    [ClientRpc]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //-------------------------
        if (collision.gameObject.CompareTag("Player") && !QTE && !noquicktime)
        {
           // QTE = true;
        }
        //-------------------------
    }
    [ClientRpc]
    void ResetStun()
    {
        isStun = false;
        result_pass = true;
    }
    IEnumerator StunCountdown(float time)
    {
        yield return new WaitForSeconds(time);
    }
    [ClientRpc]
    private void quicktimeevent()
    {
        if (isLocalPlayer)
        {
           /* if (QTE)
            {
                bar.gameObject.SetActive(true);
                arrow.gameObject.SetActive(true);
                press.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.L) || quickTimePressed)
                {
                    print("L");
                    if (arrow.GetComponent<arrow>().value >= (50 - press.GetComponent<clickdis>().size) && arrow.GetComponent<arrow>().value <= (50 + press.GetComponent<clickdis>().size))
                    {
                        print("goood");
                        bar.gameObject.SetActive(false);
                        arrow.gameObject.SetActive(false);
                        press.gameObject.SetActive(false);
                        QTE = false;
                        result_pass = true;
                        quickTimePressed = false;
                    }
                    else
                    {
                        print("bad");
                        bar.gameObject.SetActive(false);
                        arrow.gameObject.SetActive(false);
                        press.gameObject.SetActive(false);
                        QTE = false;
                        result_pass = false;
                        quickTimePressed = false;
                    }
                }
            }*/
        }
       
    }
    [ClientRpc]
    void turnSprite() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if ((joystick.input.y > 0 || joystick.input.y < 0 || joystick.input.x > 0 || joystick.input.x < 0) && !QTE && !isStun)
        {
            Vector2 direc = new Vector2(Input.GetAxisRaw("Horizontal") + joystick.input.x,
            Input.GetAxisRaw("Vertical") + joystick.input.y);
            sprite.transform.up = direc;
        }
    }

    [Command]
    public void QuickTimePressed()
    {
        quickTimePressed = true;
    }

    public void getRefugee()
    {
       /* for(int i = 0; i < numOfPassenger; i++)
        {
            passenger[i] = Game
        }*/
    }
    /*
    [Command]
    void SetSprite()
    {
        //print("SetSprite");
        for(int i = 0; i < passenger.Length; i++)
        {
            if(occupiedSeat[i] != null)
            {
                SpriteRenderer temp = seats[i].GetComponent<SpriteRenderer>();
                print(temp.gameObject);
                if (occupiedSeat[i].GetComponent<Refugee>().checkRefugeeType() == "Normal")
                {
                    temp.sprite = normal;
                }
                else if(occupiedSeat[i].GetComponent<Refugee>().checkRefugeeType() == "Hurry")
                {
                    temp.sprite = hurry;
                }
                else if(occupiedSeat[i].GetComponent<Refugee>().checkRefugeeType() == "Traveler")
                {
                    temp.sprite = traveler;
                }
                
                
            }
            if(occupiedSeat[i] == null)
            {
                occupiedSeat[i] = passenger[i];
                SpriteRenderer temp = seats[i].GetComponent<SpriteRenderer>();
                temp.sprite = null;
            }

        }
    }*/
    [ClientRpc]
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
        

    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        if(netId == 11)
        {
            gameObject.name = "Player 1";
        }
        if(netId == 12)
        {
            gameObject.name = "Player 2";
        }
        if(netId == 13)
        {
            gameObject.name = "Player 3";
        }
        if(netId == 14)
        {
            gameObject.name = "Player 4";
        }
        bars = Resources.FindObjectsOfTypeAll<Bar>();
        arrows = Resources.FindObjectsOfTypeAll<ArrowObj>();
        presses = Resources.FindObjectsOfTypeAll<Press>();
        if (bars.Length > 0)
        {
            bar = bars[0];
        }
        if (arrows.Length > 0)
        {
            arrow = arrows[0];
        }
        /*if (presses.Length > 0)
        {
            press = presses[0];
        }*/
    }
}


