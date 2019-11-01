using System;

public class Cat : Feline
{
    private string Breed;

    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
        this.Sound = "Meow";
        this.WeightCoef = 0.30;
    }

    public override bool TryFeed(Type type)
    {
        if (type == typeof(Vegetable) || type == typeof(Meat))
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