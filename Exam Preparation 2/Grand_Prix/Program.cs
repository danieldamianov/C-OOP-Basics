using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        RaceTower raceTower = new RaceTower();
        raceTower.SetTrackInfo(lapsNumber, trackLength);
        while (true)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(tokens.Skip(1).ToList());
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    try
                    {
                        string text = raceTower.CompleteLaps(tokens.Skip(1).ToList());
                        if (text != string.Empty)
                        {
                            Console.WriteLine(text);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "Box":
                    raceTower.DriverBoxes(tokens.Skip(1).ToList());
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(tokens.Skip(1).ToList());
                    break;
            }
            if (raceTower.IsFinishedRace())
            {
                raceTower.Finish();
                break;
            }
        }
    }
}

