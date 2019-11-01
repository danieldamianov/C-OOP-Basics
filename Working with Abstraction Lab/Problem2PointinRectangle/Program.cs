using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Rectangle rectangle = new Rectangle();
        rectangle.TopLeft = new Point(tokens[0], tokens[1]);
        rectangle.BottomRight = new Point(tokens[2], tokens[3]);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] pointTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var point = new Point(pointTokens[0], pointTokens[1]);
            Console.WriteLine(rectangle.Contains(point));
        }
    }
}

