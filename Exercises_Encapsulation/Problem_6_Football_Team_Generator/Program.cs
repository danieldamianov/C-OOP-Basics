using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(';');
            switch (tokens[0])
            {
                case "Team":
                    try
                    {
                        teams.Add(new Team(tokens[1]));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "Add":
                    if (teams.Any(x => x.Name == tokens[1]) == false)
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                    }
                    else
                    {
                        try
                        {
                            teams.Single(x => x.Name == tokens[1]).AddPlayer(new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7])));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case "Remove":
                    if (teams.Any(x => x.Name == tokens[1]) == false)
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                    }
                    else
                    {
                        try
                        {
                            teams.Single(x => x.Name == tokens[1]).RemovePlayer(tokens[2]);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case "Rating":
                    if (teams.Count == 0)
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        break;
                    }
                    if (teams.Any(x => x.Name == tokens[1]) == false)
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine(teams.Single(x => x.Name == tokens[1]));
                    }
                    break;
            }
        }
    }
}

