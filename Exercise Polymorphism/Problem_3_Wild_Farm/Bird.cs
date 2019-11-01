using System;

public abstract class Bird : Animal
{
    private double WingSize;

    public Bird(string name, double weight, double wingSize) : base(name , weight) 
    {
        this.WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

