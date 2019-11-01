using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    public string Model { get; set; }

    public double Power { get; set; }

    public double Displacement { get; set; }

    public string Efficiency { get; set; }

    public Engine(string model , double power)
    {
        this.Model = model;
        this.Power = power;
        this.Efficiency = "n/a";
        this.Displacement = -1;
    }

    public Engine(string model , double power , double displacement) : this(model , power)
    {
        this.Displacement = displacement;
    }

    public Engine(string model, double power, string efficiency) : this(model , power)
    {
        this.Efficiency = efficiency;
    }

    public Engine(string model, double power, double displacement, string efficiency) : this(model, power , efficiency)
    {
        this.Displacement = displacement;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"  {this.Model}:");
        sb.AppendLine($"    Power: {this.Power}");
        if (this.Displacement == -1)
        {
            sb.AppendLine($"    Displacement: n/a");
        }
        else
        {
            sb.AppendLine($"    Displacement: {this.Displacement}");
        }
        sb.AppendLine($"    Efficiency: {this.Efficiency}");
        return sb.ToString();
    }
}
