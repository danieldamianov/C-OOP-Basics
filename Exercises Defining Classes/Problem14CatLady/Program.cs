using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "StreetExtraordinaire":
                    cats.Add(new StreetExtraordinaire(tokens[0], tokens[1], int.Parse(tokens[2])));
                    break;
                case "Siamese":
                    cats.Add(new Siamese(tokens[0], tokens[1], int.Parse(tokens[2])));
                    break;
                case "Cymric":
                    cats.Add(new Cymric(tokens[0], tokens[1], double.Parse(tokens[2])));
                    break;
            }
        }
        string name = Console.ReadLine();
        int index = cats.FindIndex(x => x.Name == name);
        Console.WriteLine(cats[index]);
    }
}
