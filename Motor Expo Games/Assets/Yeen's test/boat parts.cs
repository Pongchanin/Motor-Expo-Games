using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Part1
{
    public int movementspeed;
    public int power;
    public int weight;
    public int strength;
    public string name;

    Part1(string Name, int Weight, int Power, int Movementspeed, int Strength)
    {
        name = Name;
        power = Power;
        weight = Weight;
        movementspeed = Movementspeed;
        strength = Strength;
    }
    public Part1()
    {
        name = "defult";
        power = 1;
        weight = 1;
        movementspeed = 1;
        strength = 1;
    }
}

[System.Serializable]
public class Part2
{
    public int movementspeed;
    public int power;
    public int weight;
    public int strength;
    public string name;

    Part2(string Name, int Weight, int Power, int Movementspeed, int Strength)
    {
        name = Name;
        power = Power;
        weight = Weight;
        movementspeed = Movementspeed;
        strength = Strength;
    }

    public Part2()
    {
        name = "defult";
        power = 1;
        weight = 1;
        movementspeed = 1;
        strength = 1;
    }
}

[System.Serializable]
public class Part3
{
    public int movementspeed;
    public int power;
    public int weight;
    public int strength;
    public string name;

    Part3(string Name, int Weight, int Power, int Movementspeed, int Strength)
    {
        name = Name;
        power = Power;
        weight = Weight;
        movementspeed = Movementspeed;
        strength = Strength;
    }

    public Part3()
    {
        name = "defult";
        power = 1;
        weight = 1;
        movementspeed = 1;
        strength = 1;
    }
}

[System.Serializable]
public class boat
{
    public Part1 part1;
    public Part2 part2;
    public Part3 part3;
    public int power;
    public int weight;
    public int movementspeed;
    public int strength;
  

    boat(Part1 part1_, Part2 part2_, Part3 part3_)
    {
        part1 = part1_;
        part2 = part2_;
        part3 = part3_;

        power = part1_.power + part2_.power + part3_.power;
        weight = part1_.weight + part2_.weight + part3_.weight;
        movementspeed = part1_.movementspeed + part2_.movementspeed + part3_.movementspeed;
        strength = part1_.strength + part2_.strength + part3_.strength;
        
    }

    public boat()
    {
        part1 = new Part1();
        part2 = new Part2();
        part3 = new Part3();
    }
}