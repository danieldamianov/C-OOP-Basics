using System;

class Problem
{
    static void Main(string[] args)
    {
        Family family = new Family();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            family.AddMember(new Person(tokens[0], int.Parse(tokens[1])));
        }
        Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
    }
}
