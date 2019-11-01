using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public double Weight { get; set; }

    public string Color { get; set; }

    public Car(string model , Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = -1;
        this.Color = "n/a";
    }

    public Car(string model , Engine engine , double weight) : this(model , engine)
    {
        this.Weight = weight;
    }

    public Car(string model , Engine engine , string color) : this(model , engine)
    {
        this.Color = color;
    }

    public Car(string model , Engine engine , double weight , string color) : this(model , engine , weight)
    {
        this.Color = color;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Model}:");
        sb.Append(this.Engine);
        if (this.Weight == -1)
        {
            sb.AppendLine($"  Weight: n/a");
        }
        else
        {
            sb.AppendLine($"  Weight: {this.Weight}");
        }
        sb.Append($"  Color: {this.Color}");
        return sb.ToString();
    }
}
