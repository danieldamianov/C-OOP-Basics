using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<IBuyer> buyableCreatures = new List<IBuyer>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            var tokens = input.Split();
            if (tokens.Length == 4)
            {
                buyableCreatures.Add(new Citizent(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
            }
            else
            {
                buyableCreatures.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
            } 
        }

        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            if (buyableCreatures.Any(x => x.Name == name) == false)
            {
                continue;
            }
            IBuyer buyer = buyableCreatures.Single(x => x.Name == name);
            buyer.BuyFood();
        }
        Console.WriteLine(buyableCreatures.Sum(x => x.Food));
    }
}

