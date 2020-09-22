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

    void Start()
    {
        player1Solo = GameObject.FindObjectOfType<Player1_Controller_Solo>();
        temp = new GameObject();
        temp = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
