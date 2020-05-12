using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refugee : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField]
    Player1_Controller player;

    [Header("Refugee Parameter")]
    public float moveSpeed;
    [SerializeField]
    bool isPlayerAttacked;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player1_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerAttacked();
    }

    public void checkPlayerAttacked()
    {
        isPlayerAttacked = player.checkGetAttack();
    }
}
