using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    private float timer;
    public float duration;
    public float speedbonus;
    GameObject playerhitted;
    private bool timerstart = false;
    private float playerspeed;
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
                playerhitted.GetComponent<Player1_Controller>().moveSpeed = playerspeed;
                Destroy(this.gameObject);
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
        playerspeed = playerhitted.GetComponent<Player1_Controller>().moveSpeed;
        playerhitted.GetComponent<Player1_Controller>().moveSpeed += speedbonus;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2.5f);
    }
}
