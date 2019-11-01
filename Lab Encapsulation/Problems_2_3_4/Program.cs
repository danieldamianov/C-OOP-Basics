using System;


class Program
{
    static void Main(string[] args)
    {
        var team = new Team("Test");
        team.AddPlayer(new Person("Ivan", "Petrov", 48, 2000.0m));

        Console.WriteLine(team.ReserveTeam.Count);
    }
}

