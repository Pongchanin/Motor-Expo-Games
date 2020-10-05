using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockController : MonoBehaviour
{
    [Header("GameObject Parameter")]
    GameObject dock;
    [SerializeField]
    Player1_Controller_Solo player;
    [SerializeField]
    GameManager gm;

    Vector2 center;
    [SerializeField]
    float circleRadius;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        dock = this.gameObject;
        gm  = GameObject.FindObjectOfType<GameManager>();
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OverlapCircle();
    }

    private void OnMouseDown()
    {
        print("OnMouseDown: " + gameObject.name);
        print(dock.tag);
        returnRefugee();
    }

    void returnRefugee()
    {
        for(int i = 0; i < player.passenger.Length; i++)
        {
            if(player.passenger[i] != null)
            {
                print(player.passenger[i].GetComponent<Refugee>().dest);
                if (dock.CompareTag("dest1") && player.passenger[i].GetComponent<Refugee>().dest == 0)
                {
                    gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                    Destroy(player.passenger[i]);
                }
                else if (dock.CompareTag("dest2") && player.passenger[i].GetComponent<Refugee>().dest == 1)
                {
                    gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                    Destroy(player.passenger[i]);
                }
                else if (dock.CompareTag("dest3") && player.passenger[i].GetComponent<Refugee>().dest == 2)
                {
                    gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                    Destroy(player.passenger[i]);
                }
                else if (dock.CompareTag("dest4") && player.passenger[i].GetComponent<Refugee>().dest == 3)
                {
                    gm.point += player.passenger[i].GetComponent<Refugee>().scoreVal;
                    Destroy(player.passenger[i]);
                }
            }
            else
            {
                continue;
            }
            
        }
        

    }
    void OverlapCircle()
    {
        Collider2D cir = Physics2D.OverlapCircle(center, circleRadius);
        print(cir.name);

        Collider2D[] cirs = Physics2D.OverlapCircleAll(center, circleRadius);
        for (int i = 0; i < cirs.Length; i++)
        {
            print(cirs[i].name);
            if (cirs[i].GetComponent<Player1_Controller_Solo>() != null)
            {
                returnRefugee();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, circleRadius);

    }
}
