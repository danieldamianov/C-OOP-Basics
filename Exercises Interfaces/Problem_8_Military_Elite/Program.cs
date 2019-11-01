using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Soldier> soldiers = new List<Soldier>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(' ');
            switch (tokens[0])
            {
                case "Private":
                    ParsePrivate(soldiers, tokens);
                    break;
                case "LeutenantGeneral":
                    ParseLeutenantGeneral(soldiers, tokens);
                    break;
                case "Engineer":
                    ParseEngineer(soldiers, tokens);
                    break;
                case "Commando":
                    ParseCommando(soldiers, tokens);
                    break;
                case "Spy":
                    ParseSpy(soldiers, tokens);
                    break;
            }
        }
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void ParseCommando(List<Soldier> soldiers, string[] tokens)
    {
        try
        {
            soldiers.Add(new Commando(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]));
            tokens = tokens.Skip(6).ToArray();
            Commando commando = (Commando)soldiers.Last();
            for (int i = 0; i < tokens.Length; i += 2)
            {
                try
                {
                    commando.AddMission(new Mission(tokens[i], tokens[i + 1]));
                }
                catch (ArgumentException ex)
                {
                }
            }
        }
        catch (ArgumentException ex)
        {
        }
    }

    private static void ParseSpy(List<Soldier> soldiers, string[] tokens)
    {
        soldiers.Add(new Spy(tokens[1], tokens[2], tokens[3], int.Parse(tokens[4])));
    }

    private static void ParseEngineer(List<Soldier> soldiers, string[] tokens)
    {
        try
        {
            soldiers.Add(new Engineer(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]));
            tokens = tokens.Skip(6).ToArray();
            Engineer engineer = (Engineer)soldiers.Last();
            for (int i = 0; i < tokens.Length; i+=2)
            {
                engineer.AddRepair(new Repair(tokens[i], int.Parse(tokens[i + 1])));
            }
        }
        catch (ArgumentException ex)
        {
        }
    }

    private static void ParseLeutenantGeneral(List<Soldier> soldiers, string[] tokens)
    {
        soldiers.Add(new LeutenantGeneral(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4])));
        tokens = tokens.Skip(5).ToArray();
        foreach (var privateStr in tokens)
        {
            Private privateObj = (Private)soldiers.Single(x => x.Id == privateStr);
            LeutenantGeneral leutenantGeneral = (LeutenantGeneral)soldiers.Last();
            leutenantGeneral.AddPrivate(privateObj);
        }
    }

    private static void ParsePrivate(List<Soldier> soldiers, string[] tokens)
    {
        soldiers.Add(new Private(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4])));
    }
}

