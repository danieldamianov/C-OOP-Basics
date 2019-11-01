using System;
using System.Collections.Generic;

public abstract class Animal
{
    protected string Name;
    protected double Weight;
    protected int FoodEaten;
    protected string Sound;
    protected double WeightCoef;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public void Feed(Food food)
    {
        this.Weight += food.Quantity * this.WeightCoef;
        this.FoodEaten += food.Quantity;
    }

    public abstract bool TryFeed(Type type);

    public void ProduceSound()
    {
        Console.WriteLine(this.Sound);
    }
}

