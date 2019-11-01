using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Engine> engines = new List<Engine>();

        int numOfEngines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numOfEngines; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 4)
            {
                engines.Add(new Engine(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), tokens[3]));
                continue;
            }
            if (tokens.Length == 2)
            {
                engines.Add(new Engine(tokens[0], double.Parse(tokens[1])));
                continue;
            }

            try
            {
                double.Parse(tokens[2]);
                engines.Add(new Engine(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2])));
            }
            catch (Exception)
            {
                engines.Add(new Engine(tokens[0], double.Parse(tokens[1]), tokens[2]));
            }
        }

        List<Car> cars = new List<Car>();

        int numbersOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numbersOfCars; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int index = engines.FindIndex(x => x.Model == tokens[1]);
            Engine engine = engines[index];
            if (tokens.Length == 4)
            {
                cars.Add(new Car(tokens[0], engine, double.Parse(tokens[2]), tokens[3]));
                continue;
            }
            if (tokens.Length == 2)
            {
                cars.Add(new Car(tokens[0], engine));
                continue;
            }
            try
            {
                double.Parse(tokens[2]);
                cars.Add(new Car(tokens[0], engine, double.Parse(tokens[2])));
            }
            catch (Exception)
            {
                cars.Add(new Car(tokens[0], engine, tokens[2]));
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

