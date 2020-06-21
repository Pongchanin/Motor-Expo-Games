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

    void Start()
    {
        Application.targetFrameRate = 60;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle;
        if (joystick.input.x > 0 ||joystick.input.x < 0  )
        {
            transform.Translate(new Vector3(joystick.input.x * moveSpeed * Time.deltaTime, 0f, 0f));
            /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
            print("X: " + joystick.input.x);
           // transform.rotation = new Quaternion(0, 0, 180 * joystick.input.x,0);
        }
        if (joystick.input.y > 0 || joystick.input.y < 0)
        {
            transform.Translate(new Vector3(0f, joystick.input.y * moveSpeed * Time.deltaTime, 0f));
            /*angle = Mathf.Atan2(joystick.input.y, joystick.input.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
            print("Y: " + joystick.input.y);
        }
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            print("X: " + Input.GetAxisRaw("Horizontal"));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
           transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            print("Y: " + Input.GetAxisRaw("Vertical"));
        }
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
            print("RescuePlace collide");
            setInRescue(true);
        }

        if(collision.tag == "PlayerBase")
        {
            print("At Player Base");
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
}


