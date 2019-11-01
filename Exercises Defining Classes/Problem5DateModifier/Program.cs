using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DateModifier dateModifier = new DateModifier(Console.ReadLine(), Console.ReadLine());
        Console.WriteLine(dateModifier.diff);
    }
}
