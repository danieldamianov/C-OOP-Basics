using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>(); 
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            cars.Add(new Car(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4],
                double.Parse(tokens[5]) , int.Parse(tokens[6]),
                double.Parse(tokens[7]), int.Parse(tokens[8]),
                double.Parse(tokens[9]), int.Parse(tokens[10]),
                double.Parse(tokens[11]), int.Parse(tokens[12])));
        }
        string command = Console.ReadLine();
        if (command == "fragile")
        {
            foreach (var car in cars.Where(x => x.Cargo.CargoType == "fragile").Where(x => x.tyres.Any(y => y.TirePressure < 1.0)))
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            foreach (var car in cars.Where(x => x.Cargo.CargoType == "flamable").Where(x => x.Engine.EnginePower > 250))
            {
                Console.WriteLine(car);
            }
        }
    }
}

