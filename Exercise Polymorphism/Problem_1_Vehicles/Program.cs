using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] truckArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] busArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
        Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
        Bus bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] commandArgs = Console.ReadLine().Split();
            if (commandArgs[0] == "Drive" && commandArgs[1] == "Car")
            {
                Console.WriteLine(car.Drive(double.Parse(commandArgs[2])));
            }
            else if (commandArgs[0] == "Drive" && commandArgs[1] == "Truck")
            {
                Console.WriteLine(truck.Drive(double.Parse(commandArgs[2])));
            }
            else if (commandArgs[0] == "Drive" && commandArgs[1] == "Bus")
            {
                Console.WriteLine(bus.Drive(double.Parse(commandArgs[2])));
            }
            else if (commandArgs[0] == "Refuel" && commandArgs[1] == "Car")
            {
                try
                {
                    car.Refuel(double.Parse(commandArgs[2]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (commandArgs[0] == "Refuel" && commandArgs[1] == "Truck")
            {
                try
                {
                    truck.Refuel(double.Parse(commandArgs[2]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (commandArgs[0] == "Refuel" && commandArgs[1] == "Bus")
            {
                try
                {
                    bus.Refuel(double.Parse(commandArgs[2]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if(commandArgs[0] == "DriveEmpty" && commandArgs[1] == "Bus")
            {
                Console.WriteLine(bus.DriveEmpty(double.Parse(commandArgs[2])));
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}

