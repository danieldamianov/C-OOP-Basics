using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private List<Topping> toppings;

    private Dough dough;

    public Dough Dough
    {
        set { dough = value; }
    }

    public Pizza(string name , Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.toppings = new List<Topping>();
    }

    public Pizza()
    {
    }

    public int NumberOfToppings => this.toppings.Count;

    public decimal TotalCalories => this.toppings.Sum(t => t.CalculateCalories()) + this.dough.CalculateCallories();

    public void AddTopping(Topping topping)
    {
        if (this.NumberOfToppings == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.TotalCalories:f2} Calories.";
    }
}
