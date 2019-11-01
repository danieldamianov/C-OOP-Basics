using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Trainer> list = new List<Trainer>();
        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (list.Any(x => x.Name == tokens[0]) == false)
            {
                list.Add(new Trainer(tokens[0]));
            }
            int index = list.FindIndex(x => x.Name == tokens[0]);
            list[index].Pokemons.Add(new Pokemon(tokens[1], tokens[2], double.Parse(tokens[3])));
        }

        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in list)
            {
                if (trainer.Pokemons.Exists(x => x.Element == input))
                {
                    trainer.NumberOfBadges++;
                }
                else
                {
                    trainer.Pokemons = trainer.Pokemons.Select(x => new Pokemon(x.Name,x.Element,x.Health - 10)).Where(x => x.Health > 0).ToList();
                }
            }
        }

        foreach (var tr in list.OrderByDescending(x => x.NumberOfBadges))
        {
            Console.WriteLine(tr);
        }

    }        
}

