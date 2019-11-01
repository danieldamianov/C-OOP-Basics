using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        this.Sound = "Hoot Hoot";
        this.WeightCoef = 0.25;
    }

    public override bool TryFeed(Type type)
    {
        if (type == typeof(Meat))
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

