using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> list = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            list.Add(new Person(tokens[0], tokens[1], int.Parse(tokens[2])));
        }
        foreach (var per in list.OrderBy(x => x.FirstName).ThenBy(x => x.Age))
        {
            Console.WriteLine(per);
        }
    }
}

