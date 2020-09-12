using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public Animator anim1;
    public Animator Anim2;
    public int value;
    void Update()
    {
        anim1.SetInteger("PlayerNo", value);
        Anim2.SetInteger("PlayerNo", value);
        print(value);
    }

    void Awake()
    {
        StartCoroutine(ExecuteAfterTime(1));
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        boatstatus.thisisplayer = value;

    }

}
