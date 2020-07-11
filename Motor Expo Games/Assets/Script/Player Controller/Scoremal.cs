using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoremal : MonoBehaviour
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
            playerhitted.GetComponent<Player1_Controller>().scoreMultiplier = playermal;
            Destroy(this.gameObject);
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
        playermal = playerhitted.GetComponent<Player1_Controller>().scoreMultiplier;
        playerhitted.GetComponent<Player1_Controller>().scoreMultiplier += scoremulti;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2.5f);
    }
}
