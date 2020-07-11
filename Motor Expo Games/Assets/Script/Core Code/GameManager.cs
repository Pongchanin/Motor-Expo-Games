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
    public GameObject[] refugeePrefab;
    Transform rescueBasePos;

    public Transform[] spawnPts;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller>();
        rescueBasePos = GameObject.FindGameObjectWithTag("RescuePlace").transform;
        InvokeRepeating("SpawnRefugee",0f,.5f);
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
        RescueUI.text = curRefugee.ToString();

        getNumOfRefugee();
    }

    void CountDown()
    {
        if(time >= 0)
        {
            time -= Time.deltaTime;
        }

        else
        {
            Time.timeScale = 0;
            SaveScore();
            Time.timeScale = 1;
            Application.LoadLevel("LoseScene");

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
        int rand = Mathf.CeilToInt(Random.Range(0, spawnPts.Length-1));
        //int randDest = Mathf.CeilToInt(Random.Range(0, spawnPts.Length - 1));

        if (curRefugee < limitRefugee)
        {
            int randInt;
            randInt = (int)Random.Range(0, 3);
          /*  if(rand == randDest)
            {
                if(randDest == spawnPts.Length - 1)
                {
                    randDest = 0;
                }
                else
                {
                    randDest = rand + 1;
                }
            }*/

            Instantiate(refugeePrefab[randInt], new Vector3(spawnPts[rand].localPosition.x
                , spawnPts[rand].localPosition.y),Quaternion.identity);
        }


    }
    void SaveScore()
    {
        PlayerPrefs.SetInt("Score", point);
    }
}
