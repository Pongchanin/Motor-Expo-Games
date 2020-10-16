using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Obsolete]
public class Scoremal : NetworkBehaviour
{
    private float timer;
    public float duration;
    public float scoremulti;
    GameObject playerhitted;
    private bool timerstart = false;
    private float playermal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
        }

        if (timer == 0 && timerstart)
        {
            if(playerhitted.GetComponent<Player1_Controller_Solo>() != null)
            {
                playerhitted.GetComponent<Player1_Controller_Solo>().scoreMultiplier = playermal;
                Destroy(this.gameObject);
            }
            else if (playerhitted.GetComponent<Player1_Controller_Mult>() != null)
            {
                playerhitted.GetComponent<Player1_Controller_Mult>().scoreMultiplier = playermal;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerhitted = collision.gameObject;
            StartCoroutine(itemgetto());
        }
    }
    private IEnumerator itemgetto()
    {
        timer = duration;
        timerstart = true;
        if(playerhitted.GetComponent<Player1_Controller_Mult>() != null)
        {
            playermal = playerhitted.GetComponent<Player1_Controller_Mult>().scoreMultiplier;
            playerhitted.GetComponent<Player1_Controller_Mult>().scoreMultiplier += scoremulti;
        }
        else
        {
            playermal = playerhitted.GetComponent<Player1_Controller_Solo>().scoreMultiplier;
            playerhitted.GetComponent<Player1_Controller_Solo>().scoreMultiplier += scoremulti;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2.5f);
    }
}
