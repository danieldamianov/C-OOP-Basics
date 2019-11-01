using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        string input1 , input2;
        while ((input1 = Console.ReadLine()) != "Beast!")
        {
            input2 = Console.ReadLine();
            var tokens = input2.Split(' ');
            var count = tokens.Length;
            try
            {
                switch (input1)
                {
                    case "Dog":
                        if (count < 3)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        animals.Add(new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]));
                        break;
                    case "Cat":
                        if (count < 3)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        animals.Add(new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]));
                        break;
                    case "Frog":
                        if (count < 3)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        animals.Add(new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]));
                        break;
                    case "Kitten":
                        if (count < 3)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        animals.Add(new Kitten(tokens[0], int.Parse(tokens[1]), ""));
                        break;
                    case "Tomcat":
                        if (count < 3)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        animals.Add(new Tomcat(tokens[0], int.Parse(tokens[1]), ""));
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetType());
            Console.WriteLine(animal);
            animal.ProduceSound();
        }
    }
}
