using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (people.Exists(x => x.Name == tokens[0]) == false)
            {
                people.Add(new Person(tokens[0]));
            }
            int index = people.FindIndex(x => x.Name == tokens[0]);
            switch (tokens[1])
            {
                case "company":
                    people[index].Company = new Company(tokens[2], tokens[3], double.Parse(tokens[4] , System.Globalization.NumberStyles.AllowDecimalPoint));
                    break;
                case "pokemon":
                    people[index].Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
                    break;
                case "parents":
                    people[index].Parents.Add(new Relative(tokens[2], tokens[3]));
                    break;
                case "children":
                    people[index].Children.Add(new Relative(tokens[2], tokens[3]));
                    break;
                case "car":
                    people[index].Car = new Car(tokens[2], int.Parse(tokens[3]));
                    break;
            }
        }

        string name = Console.ReadLine();
        int finalIndex = people.FindIndex(x => x.Name == name);
        Console.WriteLine(people[finalIndex]);
    }
}


