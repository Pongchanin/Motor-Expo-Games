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
    void Start()
    {
        player = GetComponentInParent<Player1_Controller_Solo>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        sprite.sprite = player.boatSprite;
        print(player.boatSprite);
    }
}
