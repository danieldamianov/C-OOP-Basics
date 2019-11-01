using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private string flourType;

    public string FlourType
    {
        get { return flourType; }
        private set
        { 
            if (value.ToLower() != "white" &&  value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value.ToLower();
        }
    }

    private string bakingTechnique;

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value.ToLower();
        }
    }

    private decimal weight;

    public decimal Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public Dough(string flourType , string bakingTechnique , decimal weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public Dough()
    {
    }

    public decimal CalculateCallories()
    {
        decimal flourTypeModifier = 0;
        switch (this.flourType)
        {
            case "white":
                flourTypeModifier = 1.5m;
                break;
            case "wholegrain":
                flourTypeModifier = 1.0m;
                break;
        }

        decimal bakingTechniqueModifier = 0;
        switch (this.bakingTechnique)
        {
            case "crispy":
                bakingTechniqueModifier = 0.9m;
                break;
            case "chewy":
                bakingTechniqueModifier = 1.1m;
                break;
            case "homemade":
                bakingTechniqueModifier = 1.0m;
                break;
        }

        decimal calories = 2m * this.weight * flourTypeModifier * bakingTechniqueModifier;

        return calories;
    }

}

