using System;
using System.Collections.Generic;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        this.Sound = "Cluck";
        this.WeightCoef = 0.35;
    }

    public override bool TryFeed(Type type)
    {
        return true;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}