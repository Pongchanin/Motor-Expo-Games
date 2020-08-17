using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{

    protected Joystick joystick;
    protected JoyButton joybutton;

    [Header("Player Parameter")] 
    public float moveSpeed;
    public float stunDuration;
    public float scoreMultiplier;

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

    Vector2 movement;

    //----------------------
    private bool QTE = false;
    private bool result_pass = true;
    public bool noquicktime = false;
    public GameObject bar;
    public GameObject arrow;
    public GameObject press;
    public GameObject sprite;

    bool quickTimePressed;


    void Start()
    {
        Application.targetFrameRate = 60;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
        bar = GameObject.Find("Bar");
        arrow = GameObject.Find("arrow");
        press = GameObject.Find("press");

        if(bar != null)
        {
            bar.SetActive(false);
        }
        if(arrow != null)
        {
            arrow.SetActive(false);
        }
        if(press != null)
        {
            press.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float angle;
        
        if ((joystick.input.x > 0 ||joystick.input.x < 0) && isStun != true && !QTE)
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
        print(transform.position);
    }

    public bool checkGetAttack()
    {
       return getAttack;
    }
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

    public bool getIsStun()
    {
        return isStun;
    }
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
        if(collision.tag == "RescuePlace")
        {
            //print("RescuePlace collide");
            setInRescue(true);
        }

        if(collision.tag == "PlayerBase")
        {
            //print("At Player Base");
            setAtBase(true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] refugees = Physics2D.OverlapCircleAll(transform.position, 5f);
        for (int i = 0; i < refugees.Length; i++)
        {
            if (refugees[i].tag == "RescuePeople")
            {
                Refugee temp = refugees[i].GetComponent<Refugee>();
                if (temp.moveWithPlayer)
                {
                    NumOfRescue += 1;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "RescuePlace")
        {
            print("Exit from RescuePlace");
            setInRescue(false);
        }
        
        if (collision.tag == "PlayerBase")
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
                if (temp.moveWithPlayer)
                {
                    NumOfRescue -= 1;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //-------------------------
        if (collision.gameObject.tag == "Player" && !QTE && !noquicktime)
        {
            QTE = true;
        }
        //-------------------------
    }
    void ResetStun()
    {
        isStun = false;
        result_pass = true;
    }
    IEnumerator StunCountdown(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void quicktimeevent()
    {
        if (QTE)
        {
            bar.SetActive(true);
            arrow.SetActive(true);
            press.SetActive(true);

            if (Input.GetKeyDown(KeyCode.L) || quickTimePressed)
            {
                print("L");
                if (arrow.GetComponent<arrow>().value >= (50 - press.GetComponent<clickdis>().size) && arrow.GetComponent<arrow>().value <= (50 + press.GetComponent<clickdis>().size))
                {
                    print("goood");
                    bar.SetActive(false);
                    arrow.SetActive(false);
                    press.SetActive(false);
                    QTE = false;
                    result_pass = true;
                    quickTimePressed = false;
                }
                else
                {
                    print("bad");
                    bar.SetActive(false);
                    arrow.SetActive(false);
                    press.SetActive(false);
                    QTE = false;
                    result_pass = false;
                    quickTimePressed = false;
                }
            }
        }
    }
    void turnSprite(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direc = new Vector2(Input.GetAxisRaw("Horizontal") + joystick.input.x,
                Input.GetAxisRaw("Vertical") + joystick.input.y); 

            
        sprite.transform.up = direc;
    }

    public void QuickTimePressed()
    {
        quickTimePressed = true;
    }
}


