using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteCheat : MonoBehaviour
{
    // Start is called before the first frame update]
    [SerializeField]
    Player1_Controller_Solo player;
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Player1_Controller_Mult playermulti;

    void Start()
    {
        if (GameObject.FindObjectOfType<Player1_Controller_Solo>() != null)
        {
            player = GetComponentInParent<Player1_Controller_Solo>();
            sprite = GetComponent<SpriteRenderer>();
        }
        else
        {
            playermulti = GetComponentInParent<Player1_Controller_Mult>();
            sprite = GetComponent<SpriteRenderer>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<Player1_Controller_Solo>() != null)
        {
            sprite.sprite = player.boatSprite;
        }
        else
        {
            //sprite.sprite = playermulti.boatSprite;
        }
    }
}
