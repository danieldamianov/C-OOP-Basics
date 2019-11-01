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
            cars.Add(new Car(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2])));
        }
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int index = cars.FindIndex(x => x.Model == tokens[1]);
            cars[index].Move(double.Parse(tokens[2]));
        }
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
