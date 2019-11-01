using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Rectangle> dictionary = new Dictionary<string, Rectangle>();

        int[] numberOfChecks = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        for (int i = 0; i < numberOfChecks[0]; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (dictionary.ContainsKey(tokens[0]) == false)
            {
                dictionary.Add(tokens[0], new Rectangle(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]), double.Parse(tokens[4])));
            }
        }

        for (int i = 0; i < numberOfChecks[1]; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
            Rectangle rectangle = dictionary[tokens[0]];
            Console.WriteLine(rectangle.IntersectsWith(dictionary[tokens[1]]).ToString().ToLower());
        }
    }
}
