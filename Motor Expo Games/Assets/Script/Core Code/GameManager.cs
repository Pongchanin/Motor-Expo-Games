using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public int point;
    [SyncVar]public float time;
    [SerializeField]
    int OnRescue;
    Player1_Controller_Solo playerSolo;
    Player1_Controller player;

    public Text ScoreUI;
    [SyncVar] public Text TimeUI;

    public Text RescueUI;

    [Header("Game Parameter")]
    [SyncVar]public int limitRefugee;
    [SerializeField]
    [SyncVar] int curRefugee;
    public GameObject[] refugeePrefab;

    [Header("Item Parameter")]
    [SyncVar] public int limitItem;
    [SerializeField]
    [SyncVar] int curItem;
    [SyncVar] public GameObject[] itemPrefab;

    Transform rescueBasePos;

    [SyncVar]public Transform[] spawnPts;
    [SyncVar]public Transform[] itemSpawnPts;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindObjectOfType<Player1_Controller>() != null)
        {
            player = GameObject.FindObjectOfType<Player1_Controller>();
        }
        else
        {
            player = null;
            playerSolo = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        }
        
        //rescueBasePos = GameObject.FindGameObjectWithTag("RescuePlace").transform;
        InvokeRepeating("SpawnRefugee",0f,1.5f);
        InvokeRepeating("SpawnItem", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI.text = point.ToString();

        /// (int)time.ToString() --> Invalid because it will convert (time.ToString()) to int;  Ex. int(f(x).ToString())
        /// using ((int)time).ToString() instead. Because it will cast "time" as int then convert to string;  Ex. (int(f(x)).ToString()


        TimeUI.text = ((int)time).ToString();
        CountDown();
        if(player != null)
        {
            OnRescue = player.NumOfRescue;
        }
        else
        {
            OnRescue = playerSolo.NumOfRescue;
        }
       
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
            SceneManager.LoadScene("LoseScene");

        }
    }
    [Server]
    void getNumOfRefugee()
    {
        Refugee[] refugee;
        refugee = GameObject.FindObjectsOfType<Refugee>();
        curRefugee = refugee.Length; 
    }
    [Server]
    void SpawnRefugee()
    {
        int rand = Mathf.CeilToInt(Random.Range(0, spawnPts.Length-1));
        //int randDest = Mathf.CeilToInt(Random.Range(0, spawnPts.Length - 1));

        if (curRefugee < limitRefugee)
        {
            int randInt;
            randInt = (int)Random.Range(0, 3);

            Instantiate(refugeePrefab[randInt], new Vector3(spawnPts[rand].localPosition.x
                , spawnPts[rand].localPosition.y),Quaternion.identity);
        }


    }
    [Server]
    void SpawnItem()
    {
        int rand = Mathf.CeilToInt(Random.Range(0, itemSpawnPts.Length - 1));
        //int randDest = Mathf.CeilToInt(Random.Range(0, spawnPts.Length - 1));

        if (curItem < limitItem)
        {
            int randInt;
            randInt = (int)Random.Range(0, 3);

            Instantiate(itemPrefab[randInt], new Vector3(itemSpawnPts[rand].position.x
                , itemSpawnPts[rand].position.y), Quaternion.identity);
        }
    }
    void SaveScore()
    {
        PlayerPrefs.SetInt("Score", point);
    }
}
