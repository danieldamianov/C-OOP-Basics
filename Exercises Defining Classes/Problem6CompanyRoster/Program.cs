using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            if (tokens.Length == 6)
            {
                employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3], tokens[4], int.Parse(tokens[5])));
                continue;
            }
            if (tokens.Length == 4)
            {
                employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3]));
                continue;
            }
            try
            {
                int.Parse(tokens[4]);
                employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3] , int.Parse(tokens[4])));
            }
            catch (Exception)
            {
                employees.Add(new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3] , tokens[4]));
            }
        }
        Dictionary<string, List<Employee>> dictionary = new Dictionary<string, List<Employee>>();
        foreach (var emp in employees)
        {
            if (dictionary.ContainsKey(emp.Department) == false)
            {
                dictionary.Add(emp.Department, new List<Employee>());
            }
            dictionary[emp.Department].Add(emp);
        }
        dictionary = dictionary.OrderByDescending(x => x.Value.Average(y => y.Salary)).ToDictionary(x => x.Key , y => y.Value);
        Console.WriteLine($"Highest Average Salary: {dictionary.FirstOrDefault().Key}");
            foreach (var emp in dictionary.FirstOrDefault().Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine(emp);
            }
            

    }
}
