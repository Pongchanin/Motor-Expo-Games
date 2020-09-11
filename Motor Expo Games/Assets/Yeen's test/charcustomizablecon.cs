using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class charcustomizablecon : MonoBehaviour
{
    //ARRAY SETTING----------------
    [Header("array")]
    public int array1size;
    public int array2size;
    public int array3size;
    //VARIBLE FOR ARRAY CYCLING----
    public int selected1 = 0;
    public int selected2 = 0;
    public int selected3 = 0;
    //BAR--------------------------
    public Animator speed;
    public Animator power;
    public Animator weight;
    public Animator strength;
    //Arrays-----------------------
    public Part1[] array1;
    public Part2[] array2;
    public Part3[] array3;
    //VARIBLE TO SET THE VALUE-----
    [Header("turn1")]
    public int turn1movespeed;
    public int turn1weight;
    public int turn1power;
    public int turn1strength;
    [Header("turn2")]
    public int turn2movespeed;
    public int turn2weight;
    public int turn2power;
    public int turn2strength;
   /* [Header("turn3")]
    public int turn3movespeed;
    public int turn3weight;
    public int turn3power;
    */public int turn3strength;
    [Header("body1")]
    public int body1movespeed;
    public int body1weight;
    public int body1power;
    public int body1strength;
    [Header("body2")]
    public int body2movespeed;
    public int body2weight;
    public int body2power;
    public int body2strength;
    [Header("body3")]
    public int body3movespeed;
    public int body3weight;
    public int body3power;
    public int body3strength;
    [Header("ancor1")]
    public int ancor1movespeed;
    public int ancor1weight;
    public int ancor1power;
    public int ancor1strength;
    [Header("ancor2")]
    public int ancor2movespeed;
    public int ancor2weight;
    public int ancor2power;
    public int ancor2strength;
    [Header("ancor3")]
    public int ancor3movespeed;
    public int ancor3weight;
    public int ancor3power;
    public int ancor3strength;
    [Header("ancor4")]
    public int ancor4movespeed;
    public int ancor4weight;
    public int ancor4power;
    public int ancor4strength;
    [Header("animcontrolers")]
    public Animator mortor;
    public Animator shape;
    public Animator weel;

    [Header("Boat Completed")]
    public Image selected;
    public Sprite[] BoatPics;
    [SerializeField]
    int index;
    //public boat thisboat;

    void Start()
    {
        partvaluesetting();
        array();
        selected.sprite = BoatPics[0];
    }

    void Update()
    {
        speed.SetInteger("value", (array1[selected1].movementspeed + array2[selected2].movementspeed + array3[selected3].movementspeed));
        weight.SetInteger("value", (array1[selected1].weight + array2[selected2].weight + array3[selected3].weight));
        power.SetInteger("value", (array1[selected1].power + array2[selected2].power + array3[selected3].power));
        strength.SetInteger("value", (array1[selected1].strength + array2[selected2].strength + array3[selected3].strength));

        mortor.SetInteger("selected1", selected1);
        shape.SetInteger("selected2", selected2);
        weel.SetInteger("selected3", selected3);

        changeBoatFinished();

    }
    void partvaluesetting()
    {
        boatstatus.Turn1.movementspeed = turn1movespeed;
        boatstatus.Turn1.weight = turn1weight;
        boatstatus.Turn1.power = turn1power;
        boatstatus.Turn1.strength = turn1strength;
        //-------------------------------------------------------
        boatstatus.Turn2.movementspeed = turn2movespeed;
        boatstatus.Turn2.weight = turn2weight;
        boatstatus.Turn2.power = turn2power;
        boatstatus.Turn2.strength = turn2strength;
        //-------------------------------------------------------
        /*boatstatus.Turn3.movementspeed = turn3movespeed;
        boatstatus.Turn3.weight = turn3weight;
        boatstatus.Turn3.power = turn3power;
        boatstatus.Turn3.strength = turn3strength;*/
        //-------------------------------------------------------
        boatstatus.Body1.movementspeed = body1movespeed;
        boatstatus.Body1.weight = body1weight;
        boatstatus.Body1.power = body1power;
        boatstatus.Body1.strength = body1strength;
        //-------------------------------------------------------
        boatstatus.Body2.movementspeed = body2movespeed;
        boatstatus.Body2.weight = body2weight;
        boatstatus.Body2.power = body2power;
        boatstatus.Body2.strength = body2strength;
        //-------------------------------------------------------
        boatstatus.Body3.movementspeed = body3movespeed;
        boatstatus.Body3.weight = body3weight;
        boatstatus.Body3.power = body3power;
        boatstatus.Body3.strength = body3strength;
        //-------------------------------------------------------
        boatstatus.Ancor1.movementspeed = ancor1movespeed;
        boatstatus.Ancor1.weight = ancor1weight;
        boatstatus.Ancor1.power = ancor1power;
        boatstatus.Ancor1.strength = ancor1strength;
        //-------------------------------------------------------
        boatstatus.Ancor2.movementspeed = ancor2movespeed;
        boatstatus.Ancor2.weight = ancor2weight;
        boatstatus.Ancor2.power = ancor2power;
        boatstatus.Ancor2.strength = ancor2strength;
        //-------------------------------------------------------
        boatstatus.Ancor3.movementspeed = ancor3movespeed;
        boatstatus.Ancor3.weight = ancor3weight;
        boatstatus.Ancor3.power = ancor3power;
        boatstatus.Ancor3.strength = ancor3strength;
        //-------------------------------------------------------
        boatstatus.Ancor4.movementspeed = ancor4movespeed;
        boatstatus.Ancor4.weight = ancor4weight;
        boatstatus.Ancor4.power = ancor4power;
        boatstatus.Ancor4.strength = ancor4strength;
        //-------------------------------------------------------
    }
    void array()
    {
        array1 = new Part1[array1size];
        for (int i = 0; i < array1.Length; i++)
        {
            array1[i] = new Part1();
        }    
        array1[0] = boatstatus.Turn1;
        array1[1] = boatstatus.Turn2;
        //array1[2] = boatstatus.Turn3;

        array2 = new Part2[array2size];
        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = new Part2();
        }
        array2[0] = boatstatus.Body1;
        array2[1] = boatstatus.Body2;
        array2[2] = boatstatus.Body3;

        array3 = new Part3[array3size];
        for (int i = 0; i < array3.Length; i++)
        {
            array3[i] = new Part3();
        }
        array3[0] = boatstatus.Ancor1;
        array3[1] = boatstatus.Ancor2;
        array3[2] = boatstatus.Ancor3;
        array3[3] = boatstatus.Ancor4;
    }
    public void button1up()
    {
        if (selected1 >= array1.Length -1)
        {
            selected1 = 0;
        }
        else
        {
            selected1 += 1;
        }
    }
    public void button2up()
    {
        if (selected2 >= array2.Length -1)
        {
            selected2 = 0;
        }
        else
        {
            selected2 += 1;
        }
    }
    public void button3up()
    {
        if (selected3 >= array3.Length -1)
        {
            selected3 = 0;
        }
        else
        {
            selected3 += 1;
        }
    }
    public void button1down()
    {
        if (selected1 <= 0)
        {
            selected1 = array1.Length -1;
        }
        else
        {
            selected1 -= 1;
        }
    }
    public void button2down()
    {
        if (selected2 <= 0)
        {
            selected2 = array2.Length -1;
        }
        else
        {
            selected2 -= 1;
        }
    }
    public void button3down()
    {
        if (selected3 <= 0)
        {
            selected3 = array3.Length -1;
        }
        else
        {
            selected3 -= 1;
        }
    }
    
    public void finish()
    {
        boatstatus.Player1.part1 = array1[selected1];
        boatstatus.Player1.part2 = array2[selected2];
        boatstatus.Player1.part3 = array3[selected3];

        boatstatus.Player1.power = array1[selected1].power + array2[selected2].power + array3[selected3].power;
        boatstatus.Player1.weight = array1[selected1].weight + array2[selected2].weight + array3[selected3].weight;
        boatstatus.Player1.movementspeed = array1[selected1].movementspeed + array2[selected2].movementspeed + array3[selected3].movementspeed;
        boatstatus.Player1.strength = array1[selected1].strength + array2[selected2].strength + array3[selected3].strength;
        StartCoroutine(Finish(8));
    }

    IEnumerator Finish(int buildindex)
    {
        GetComponent<MenuScript>().transition.SetTrigger("start");
        yield return new WaitForSeconds(GetComponent<MenuScript>().transitionTime);
        SceneManager.LoadScene(buildindex);
    }

    void changeBoatFinished()
    {
        
        if(selected1 == 0)
        {
            if (selected2 == 0) {
                if(selected3 == 0)
                {
                    index = 0;
                }
                else if(selected3 == 1)
                {
                    index = 1;
                }
                else if(selected3 == 2)
                {
                    index = 2;
                }
                else if (selected3 == 3)
                {
                    index = 3;
                }
            }
            else if (selected2 == 1)
            {
                if (selected3 == 0)
                {
                    index = 12;
                }
                else if (selected3 == 1)
                {
                    index = 13;
                }
                else if (selected3 == 2)
                {
                    index = 14;
                }
                else if (selected3 == 3)
                {
                    index = 15;
                }
            }
            else if (selected2 == 2)
            {
                if (selected3 == 0)
                {
                    index = 24;
                }
                else if (selected3 == 1)
                {
                    index = 25;
                }
                else if (selected3 == 2)
                {
                    index = 26;
                }
                else if (selected3 == 3)
                {
                    index = 27;
                }
            }
            else if (selected2 == 3)
            {
                if (selected3 == 0)
                {
                    index = 24;
                }
                else if (selected3 == 1)
                {
                    index = 25;
                }
                else if (selected3 == 2)
                {
                    index = 26;
                }
                else if (selected3 == 3)
                {
                    index = 27;
                }
            }
            else if (selected2 == 4)
            {
                if (selected3 == 0)
                {
                    index = 32;
                }
                else if (selected3 == 1)
                {
                    index = 33;
                }
                else if (selected3 == 2)
                {
                    index = 34;
                }
                else if (selected3 == 3)
                {
                    index = 35;
                }
            }
        }
        else if(selected1 == 1)
        {
            if (selected2 == 0)
            {
                if (selected3 == 0)
                {
                    index = 4;
                }
                else if (selected3 == 1)
                {
                    index = 5;
                }
                else if (selected3 == 2)
                {
                    index = 6;
                }
                else if (selected3 == 3)
                {
                    index = 7;
                }
            }
            else if (selected2 == 1)
            {
                if (selected3 == 0)
                {
                    index = 16;
                }
                else if (selected3 == 1)
                {
                    index = 17;
                }
                else if (selected3 == 2)
                {
                    index = 18;
                }
                else if (selected3 == 3)
                {
                    index = 19;
                }
            }
            else if (selected2 == 2)
            {
                if (selected3 == 0)
                {
                    index = 28;
                }
                else if (selected3 == 1)
                {
                    index = 29;
                }
                else if (selected3 == 2)
                {
                    index = 30;
                }
                else if (selected3 == 3)
                {
                    index = 31;
                }
            }
            else if (selected2 == 3)
            {
                if (selected3 == 0)
                {
                    index = 28;
                }
                else if (selected3 == 1)
                {
                    index = 29;
                }
                else if (selected3 == 2)
                {
                    index = 30;
                }
                else if (selected3 == 3)
                {
                    index = 31;
                }
            }
        }
        selected.sprite = BoatPics[index];
    }
}
