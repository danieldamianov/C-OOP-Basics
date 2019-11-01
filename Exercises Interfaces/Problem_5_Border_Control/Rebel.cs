using System;
using System.Collections.Generic;
using System.Text;

public class Rebel : IBuyer
{
    public string Name { get;}
    private int age;
    private string group;
    public int Food { get; private set; }

    public Rebel(string name , int age ,string group)
    {
        this.Name = name;
        this.age = age;
        this.group = group;
        this.Food = 0;
    }

    public void BuyFood()
    {
        this.Food += 5;
    }
}

