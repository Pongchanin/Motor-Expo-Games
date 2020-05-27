using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charcustomizablecon : MonoBehaviour
{
    //ARRAY SETTING----------------
    [Header("array")]
    public int array1size;
    public int array2size;
    public int array3size;
    public int array4size;
    //VARIBLE FOR ARRAY CYCLING----
    int selected1 = 0;
    int selected2 = 0;
    int selected3 = 0;
    int selected4 = 0;
    //TEXT-------------------------
    public Text speed;
    public Text power;
    public Text weight;
    //Arrays-----------------------
    Part1[] array1;
    Part2[] array2;
    Part3[] array3;
    Part4[] array4;
    //VARIBLE TO SET THE VALUE-----
    [Header("turn1")]
    public int turn1movespeed;
    public int turn1weight;
    public int turn1power;
    [Header("turn2")]
    public int turn2movespeed;
    public int turn2weight;
    public int turn2power;
    //[Header("turn3")]
    //public int turn3movespeed;
    //public int turn3weight;
    //public int turn3power;
    [Header("body1")]
    public int body1movespeed;
    public int body1weight;
    public int body1power;
    [Header("body2")]
    public int body2movespeed;
    public int body2weight;
    public int body2power;
    //[Header("body3")]
    //public int body3movespeed;
    //public int body3weight;
    //public int body3power;
    [Header("ancor1")]
    public int ancor1movespeed;
    public int ancor1weight;
    public int ancor1power;
    [Header("ancor2")]
    public int ancor2movespeed;
    public int ancor2weight;
    public int ancor2power;
    //[Header("ancor3")]
    //public int ancor3movespeed;
    //public int ancor3weight;
    //public int ancor3power;
    [Header("cloth1")]
    public int cloth1movespeed;
    public int cloth1weight;
    public int cloth1power;
    [Header("cloth2")]
    public int cloth2movespeed;
    public int cloth2weight;
    public int cloth2power;
    //[Header("cloth3")]
    //public int cloth3movespeed;
    //public int cloth3weight;
    //public int cloth3power;
    [Header("animcontrolers")]
    public Animator mortor;
    public Animator shape;
    public Animator weel;


    // Start is called before the first frame update
    void Start()
    {
        partvaluesetting();
        array();
    }

    void Update()
    {
        speed.text = "Move speed: " + (array1[selected1].movementspeed + array2[selected2].movementspeed + array3[selected3].movementspeed + array4[selected4].movementspeed);
        weight.text = "weight: " + (array1[selected1].weight + array2[selected2].weight + array3[selected3].weight + array4[selected4].weight);
        power.text = "power: " + (array1[selected1].power + array2[selected2].power + array3[selected3].power + array4[selected4].power);
        mortor.SetInteger("selected1", selected1);
        shape.SetInteger("selected2", selected2);
        weel.SetInteger("selected3", selected3);
    }
    void partvaluesetting()
    {
        boatstatus.Turn1.movementspeed = turn1movespeed;
        boatstatus.Turn1.weight = turn1weight;
        boatstatus.Turn1.power = turn1power;
        //-------------------------------------------------------
        boatstatus.Turn2.movementspeed = turn2movespeed;
        boatstatus.Turn2.weight = turn2weight;
        boatstatus.Turn2.power = turn2power;
        //-------------------------------------------------------
        //boatstatus.Turn3.movementspeed = turn3movespeed;
        //boatstatus.Turn3.weight = turn3weight;
        //boatstatus.Turn3.power = turn3power;
        //-------------------------------------------------------
        boatstatus.Body1.movementspeed = body1movespeed;
        boatstatus.Body1.weight = body1weight;
        boatstatus.Body1.power = body1power;
        //-------------------------------------------------------
        boatstatus.Body2.movementspeed = body2movespeed;
        boatstatus.Body2.weight = body2weight;
        boatstatus.Body2.power = body2power;
        //-------------------------------------------------------
        //boatstatus.Body3.movementspeed = body3movespeed;
        //boatstatus.Body3.weight = body3weight;
        //boatstatus.Body3.power = body3power;
        //-------------------------------------------------------
        boatstatus.Ancor1.movementspeed = ancor1movespeed;
        boatstatus.Ancor1.weight = ancor1weight;
        boatstatus.Ancor1.power = ancor1power;
        //-------------------------------------------------------
        boatstatus.Ancor2.movementspeed = ancor2movespeed;
        boatstatus.Ancor2.weight = ancor2weight;
        boatstatus.Ancor2.power = ancor2power;
        //-------------------------------------------------------
        //boatstatus.Ancor3.movementspeed = ancor3movespeed;
        //boatstatus.Ancor3.weight = ancor3weight;
        //boatstatus.Ancor3.power = ancor3power;
        //-------------------------------------------------------
        boatstatus.cloth1.movementspeed = cloth1movespeed;
        boatstatus.cloth1.weight = cloth1weight;
        boatstatus.cloth1.power = cloth1power;
        //-------------------------------------------------------
        boatstatus.cloth2.movementspeed = cloth2movespeed;
        boatstatus.cloth2.weight = cloth2weight;
        boatstatus.cloth2.power = cloth2power;
        //-------------------------------------------------------
        //boatstatus.cloth3.movementspeed = cloth3movespeed;
        //boatstatus.cloth3.weight = cloth3weight;
        //boatstatus.cloth3.power = cloth3power;
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
        //array2[2] = boatstatus.Body3;

        array3 = new Part3[array3size];
        for (int i = 0; i < array3.Length; i++)
        {
            array3[i] = new Part3();
        }
        array3[0] = boatstatus.Ancor1;
        array3[1] = boatstatus.Ancor2;
        //array3[2] = boatstatus.Ancor3;

        array4 = new Part4[array4size];
        for (int i = 0; i < array4.Length; i++)
        {
            array4[i] = new Part4();
        }
        array4[0] = boatstatus.cloth1;
        array4[1] = boatstatus.cloth2;
        //array4[2] = boatstatus.cloth3;
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
    public void button4up()
    {
        if (selected4 >= array4.Length -1)
        {
            selected4 = 0;
        }
        else
        {
            selected4 += 1;
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
            selected2
 -= 1;
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
    public void button4down()
    {
        if (selected4 <= 0)
        {
            selected4 = array4.Length -1;
        }
        else
        {
            selected4 -= 1;
        }
    }
}
