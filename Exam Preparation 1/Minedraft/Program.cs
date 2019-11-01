using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        DraftManager draftManager = new DraftManager();
        string input;
        do
        {
            input = Console.ReadLine();
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(tokens.Skip(1).ToList()));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(tokens.Skip(1).ToList()));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(tokens.Skip(1).ToList()));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(tokens.Skip(1).ToList()));
                    break;
                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    break;

            }
        } while (input != "Shutdown");
    }
}

