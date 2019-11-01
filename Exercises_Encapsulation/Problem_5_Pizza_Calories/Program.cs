using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    { 
        string input , pizzaName = "";
        input = Console.ReadLine();
        pizzaName = input.Split()[1];
        input = Console.ReadLine();
        var firstTokens = input.Split();
        Pizza pizza = new Pizza();
        try
        {
            pizza = new Pizza(pizzaName, new Dough(firstTokens[1], firstTokens[2], decimal.Parse(firstTokens[3])));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();
            try
            {
                pizza.AddTopping(new Topping(tokens[1], decimal.Parse(tokens[2])));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
        Console.WriteLine(pizza);
    }
}

