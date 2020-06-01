using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int point;
    public float time;

    public Text ScoreUI;
    public Text TimeUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI.text = "Score: " + point;

        /// (int)time.ToString() --> Invalid because it will convert (time.ToString()) to int;  Ex. int(f(x).ToString())
        /// using ((int)time).ToString() instead. Because it will cast "time" as int then convert to string;  Ex. (int(f(x)).ToString()


        TimeUI.text = ((int)time).ToString();
        CountDown();
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
}
