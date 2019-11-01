using System;

class Program
{
    static void Main(string[] args)
    {
        Box box = new Box(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
        Console.WriteLine(box);
    }
}

