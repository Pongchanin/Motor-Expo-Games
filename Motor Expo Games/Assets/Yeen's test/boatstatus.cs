﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class boatstatus
{
    private static Part1 turn1 = new Part1();
    private static Part1 turn2 = new Part1();
    //private static Part1 turn3 = new Part1();

    private static Part2 body1 = new Part2();
    private static Part2 body2 = new Part2();
    //private static Part2 body3 = new Part2();

    private static Part3 ancor1 = new Part3();
    private static Part3 ancor2 = new Part3();
    //private static Part3 ancor3 = new Part3();

    private static Part4 Cloth1 = new Part4();
    private static Part4 Cloth2 = new Part4();
    //private static Part4 Cloth3 = new Part4();

    private static boat player1 = new boat();

    public static Part1 Turn1
    {
        get
        {
            return turn1;
        }
        set
        {
            turn1 = value;
        }
    }

    public static Part1 Turn2
    {
        get
        {
            return turn2;
        }
        set
        {
            turn2 = value;
        }
    }

    /*public static Part1 Turn3
    {
        get
        {
            return turn3;
        }
        set
        {
            turn3 = value;
        }
    }*/

    public static Part2 Body1
    {
        get
        {
            return body1;
        }
        set
        {
            body1 = value;
        }
    }

    public static Part2 Body2
    {
        get
        {
            return body2;
        }
        set
        {
            body2 = value;
        }
    }

    /*public static Part2 Body3
    {
        get
        {
            return body3;
        }
        set
        {
            body3 = value;
        }
    }*/

    public static Part3 Ancor1
    {
        get
        {
            return ancor1;
        }
        set
        {
            ancor1 = value;
        }
    }

    public static Part3 Ancor2
    {
        get
        {
            return ancor2;
        }
        set
        {
            ancor2 = value;
        }
    }

    /*public static Part3 Ancor3
    {
        get
        {
            return ancor3;
        }
        set
        {
            ancor3 = value;
        }
    }*/

    public static Part4 cloth1
    {
        get
        {
            return Cloth1;
        }
        set
        {
            Cloth1 = value;
        }
    }

    public static Part4 cloth2
    {
        get
        {
            return Cloth2;
        }
        set
        {
            Cloth2 = value;
        }
    }

    /*public static Part4 cloth3
    {
        get
        {
            return Cloth3;
        }
        set
        {
            Cloth3 = value;
        }
    }*/

    public static boat Player1
    {
        get
        {
            return player1;
        }
        set
        {
            player1 = value;
        }
    }
}
