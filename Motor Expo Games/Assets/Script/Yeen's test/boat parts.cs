using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Part1
{
    public int movementspeed;
    public int power;
    public int weight;
    public string name;

    Part1(string Name, int Weight, int Power, int Movementspeed)
    {
        name = Name;
        power = Power;
        weight = Weight;
        movementspeed = Movementspeed;
    }
    public Part1()
    {
        name = "defult";
        power = 1;
        weight = 1;
        movementspeed = 1;
    }
}

[System.Serializable]
public class Part2
{
    public int movementspeed;
    public int power;
    public int weight;
    public string name;

    Part2(string Name, int Weight, int Power, int Movementspeed)
    {
        name = Name;
        power = Power;
        weight = Weight;
        movementspeed = Movementspeed;
    }

    public Part2()
    {
        name = "defult";
        power = 1;
        weight = 1;
        movementspeed = 1;
    }
}

[System.Serializable]
public class Part3
{
    public int movementspeed;
    public int power;
    public int weight;
    public string name;

    Part3(string Name, int Weight, int Power, int Movementspeed)
    {
        name = Name;
        power = Power;
        weight = Weight;
        movementspeed = Movementspeed;
    }

    public Part3()
    {
        name = "defult";
        power = 1;
        weight = 1;
        movementspeed = 1;
    }
}

[System.Serializable]
public class Part4
{
    public int movementspeed;
    public int power;
    public int weight;
    public string name;

    Part4(string Name, int Weight, int Power, int Movementspeed)
    {
        name = Name;
        power = Power;
        weight = Weight;
        movementspeed = Movementspeed;
    }
    public Part4()
    {
        name = "defult";
        power = 1;
        weight = 1;
        movementspeed = 1;
    }
}

[System.Serializable]
public class boat
{
    public Part1 part1;
    public Part2 part2;
    public Part3 part3;
    public Part4 part4;
    public int power;
    public int weight;
    public int movementspeed;
  

    boat(Part1 part1_, Part2 part2_, Part3 part3_, Part4 part4_)
    {
        power = part1_.power + part2_.power + part3_.power + part4_.power;
        weight = part1_.weight + part2_.weight + part3_.weight + part4_.weight;
        movementspeed = part1_.movementspeed + part2_.movementspeed + part3_.movementspeed + part4_.movementspeed;
    }
}