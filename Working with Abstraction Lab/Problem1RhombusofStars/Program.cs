using System;
using System.Linq;

namespace Problem1RhombusofStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintRomb(n);
        }
        static void PrintRomb(int size)
        {
            int numberOfRows = size + size - 1;
            for (int i = 1; i <= size; i++)
            {
                PrintRoll((numberOfRows - i - i + 1) / 2, i);
            }
            for (int i = size - 1; i >= 1; i--)
            {
                PrintRoll((numberOfRows - i - i + 1) / 2, i);
            }
        }
        static void PrintRoll(int spaces , int stars)
        {
            Console.WriteLine($"{new string(' ',spaces)}{string.Join(" ",new string('*', stars).ToCharArray())}{new string(' ', spaces)}");
        }
    }
}
