using System;

public class Tiger : Feline
{
    private string Breed;

    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
        this.Sound = "ROAR!!!";
        this.WeightCoef = 1;
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
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}