using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        this.Sound = "Squeak";
        this.WeightCoef = 0.10;
    }

    public override bool TryFeed(Type type)
    {
        if (type == typeof(Vegetable) || type == typeof(Fruit))
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

