using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AddPassenger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Player1_Controller_Solo player1Solo;
    GameObject temp;
    AudioSource audioSource;
    Vector2 center;
    [SerializeField]
    float circleRadius;

    void Start()
    {
        player1Solo = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        temp = new GameObject();
        temp = gameObject;
        audioSource = GetComponent<AudioSource>();
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OverlapCircle();
    }

    private void OnMouseDown()
    {
        print("OnMouseDown:" + gameObject.name);

        CopyComp();

        //Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
      
    }
    void CopyComp()
    {
        for (int i = 0; i < player1Solo.passenger.Length; i++)
        {
            if (player1Solo.passenger[i] == null)
            {
                player1Solo.passenger[i] =  temp;
                audioSource.Play();
                gameObject.SetActive(false);
                break;
            }
            else if(player1Solo.passenger[i] != null)
            {
                continue;
            }

            //Ignored
        }
    }

    void OverlapCircle()
    {
        Collider2D temp = Physics2D.OverlapCircle(center, circleRadius);
        //print(temp.name);

        Collider2D[] temps = Physics2D.OverlapCircleAll(center, circleRadius);
        for(int i = 0; i < temps.Length; i++)
        {
          //  print(temps[i].name);
            if(temps[i].GetComponent<Player1_Controller_Solo>() != null)
            {
                CopyComp();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);

    }
}
