using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("Item Parameter")]
    public int limitItem;
    [SerializeField]
    int curItem;
    public GameObject[] itemPrefab;

    Transform rescueBasePos;

    public Transform[] spawnPts;
    public Transform[] itemSpawnPts;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller>();
        //rescueBasePos = GameObject.FindGameObjectWithTag("RescuePlace").transform;
        InvokeRepeating("SpawnRefugee",0f,.5f);
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
            SceneManager.LoadScene("LoseScene");

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

            Instantiate(refugeePrefab[randInt], new Vector3(spawnPts[rand].localPosition.x
                , spawnPts[rand].localPosition.y),Quaternion.identity);
        }


    }

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
