using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        this.Sound = "Woof!";
        this.WeightCoef = 0.40;
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