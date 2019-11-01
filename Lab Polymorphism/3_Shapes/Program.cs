using System;

public class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle(3, 4);
        Circle circle = new Circle(5);
        Console.WriteLine($"{circle.CalculateArea():f2}");
        Console.WriteLine($"{circle.CalculatePerimeter():f2}");
        Console.WriteLine(circle.Draw());
    }
}

