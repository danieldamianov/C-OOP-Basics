using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[] splittedPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        foreach (var personSplited in splittedPeople)
        {
            var tokens = personSplited.Split('=', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                people.Add(new Person(tokens[0], decimal.Parse(tokens[1])));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        string[] splittedProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        foreach (var productSplited in splittedProducts)
        {
            var tokens = productSplited.Split('=', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                products.Add(new Product(tokens[0], decimal.Parse(tokens[1])));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var productName = tokens[1];

            var person = people.Single(x => x.Name == name);
            var product = products.Single(x => x.Name == productName);

            if (person.CurrentMoney < product.Cost)
            {
                Console.WriteLine($"{name} can't afford {productName}");
            }
            else
            {
                person.Products.Add(product);
                Console.WriteLine($"{name} bought {productName}");
            }
        }

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}
