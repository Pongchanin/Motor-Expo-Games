using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int point;
    public float time;
    [SerializeField]
    int OnRescue;
    Player1_Controller player;

    public Text ScoreUI;
    public Text TimeUI;

    public Text RescueUI;

    [Header("Game Parameter")]
    public int limitRefugee;
    [SerializeField]
    int curRefugee;
    public GameObject refugeePrefab;
    Transform rescueBasePos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller>();
        rescueBasePos = GameObject.FindGameObjectWithTag("RescuePlace").transform;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI.text = point.ToString();

        /// (int)time.ToString() --> Invalid because it will convert (time.ToString()) to int;  Ex. int(f(x).ToString())
        /// using ((int)time).ToString() instead. Because it will cast "time" as int then convert to string;  Ex. (int(f(x)).ToString()


        TimeUI.text = ((int)time).ToString();
        CountDown();
        OnRescue = player.NumOfRescue;
        RescueUI.text = OnRescue.ToString();

        getNumOfRefugee();
        SpawnRefugee();
    }

    void CountDown()
    {
        if(time >= 0)
        {
            time -= Time.deltaTime;
        }

        else
        {
            //Do something, when time ran out
        }
    }
    void getNumOfRefugee()
    {
        Refugee[] refugee;
        refugee = GameObject.FindObjectsOfType<Refugee>();
        curRefugee = refugee.Length; 
    }
    void SpawnRefugee()
    {
        if(curRefugee < limitRefugee)
        {
            Instantiate(refugeePrefab, rescueBasePos);
        }
    }
}
