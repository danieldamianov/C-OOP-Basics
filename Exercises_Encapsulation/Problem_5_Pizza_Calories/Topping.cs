using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private string type;
    private string typeCaseSensitive;
    public string Type
    {
        get { return type; }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value.ToLower();
        }
    }

    private decimal weight;

    public decimal Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.typeCaseSensitive} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string type , decimal weight)
    {
        this.Type = type;
        this.typeCaseSensitive = type;
        this.Weight = weight;
    }

    public decimal CalculateCalories()
    {
        decimal typeModifier = 0;
        switch (this.type)
        {
            case "meat":
                typeModifier = 1.2m;
                break;
            case "veggies":
                typeModifier = 0.8m;
                break;
            case "cheese":
                typeModifier = 1.1m;
                break;
            case "sauce":
                typeModifier = 0.9m;
                break;
        }

        return 2m * this.weight * typeModifier;
    }

}

