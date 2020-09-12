using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class boatstatus
{
    private static Part1 turn1 = new Part1();
    private static Part1 turn2 = new Part1();
    //private static Part1 turn3 = new Part1();

    private static Part2 body1 = new Part2();
    private static Part2 body2 = new Part2();
    private static Part2 body3 = new Part2();

    private static Part3 ancor1 = new Part3();
    private static Part3 ancor2 = new Part3();
    private static Part3 ancor3 = new Part3();
    private static Part3 ancor4 = new Part3();

    private static boat player1 = new boat();
    private static boat player2 = new boat();
    private static boat player3 = new boat();
    private static boat player4 = new boat();



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
    }
    */
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

    public static Part2 Body3
    {
        get
        {
            return body3;
        }
        set
        {
            body3 = value;
        }
    }

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

    public static Part3 Ancor3
    {
        get
        {
            return ancor3;
        }
        set
        {
            ancor3 = value;
        }
    }

    public static Part3 Ancor4
    {
        get
        {
            return ancor4;
        }
        set
        {
            ancor4 = value;
        }
    }

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

    public static boat Player2
    {
        get
        {
            return player2;
        }
        set
        {
            player2 = value;
        }
    }

    public static boat Player3
    {
        get
        {
            return player3;
        }
        set
        {
            player3 = value;
        }
    }

    public static boat Player4
    {
        get
        {
            return player4;
        }
        set
        {
            player4 = value;
        }
    }
}
