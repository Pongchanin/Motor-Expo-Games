using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noquicktime : MonoBehaviour
{
    private float timer;
    public float duration;
    GameObject playerhitted;
    private bool timerstart = false;
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
            if(playerhitted != null)
            {
                if (playerhitted.GetComponent<Player1_Controller>() != null)
                {
                    playerhitted.GetComponent<Player1_Controller>().noquicktime = false;
                    Destroy(this.gameObject);
                }
                else
                {
                    playerhitted.GetComponent<Player1_Controller_Solo>().noquicktime = false;
                    Destroy(this.gameObject);
                }

            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerhitted = collision.gameObject;
            StartCoroutine(itemgetto());
        }
    }
    private IEnumerator itemgetto()
    {
        timer = duration;
        timerstart = true;

        if (playerhitted.GetComponent<Player1_Controller>() != null)
        {
            playerhitted.GetComponent<Player1_Controller>().noquicktime = true;
        }
        else
        {
            playerhitted.GetComponent<Player1_Controller_Solo>().noquicktime = true;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2.5f);
    }
}
