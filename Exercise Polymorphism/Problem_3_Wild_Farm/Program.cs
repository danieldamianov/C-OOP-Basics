using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string input;
        List<Animal> animals = new List<Animal>();
        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] foodTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Animal animal = null;
            Food food = null;
            switch (animalTokens[0])
            {
                case "Mouse":
                    animal = new Mouse(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3]);
                    break;
                case "Dog":
                    animal = new Dog(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3]);
                    break;
                case "Owl":
                    animal = new Owl(animalTokens[1], double.Parse(animalTokens[2]), double.Parse(animalTokens[3]));
                    break;
                case "Hen":
                    animal = new Hen(animalTokens[1], double.Parse(animalTokens[2]), double.Parse(animalTokens[3]));
                    break;
                case "Cat":
                    animal = new Cat(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3], animalTokens[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3], animalTokens[4]);
                    break;
            }

            switch (foodTokens[0])
            {
                case "Fruit":
                    food = new Fruit(int.Parse(foodTokens[1]));
                    break;
                case "Meat":
                    food = new Meat(int.Parse(foodTokens[1]));
                    break;
                case "Seeds":
                    food = new Seeds(int.Parse(foodTokens[1]));
                    break;
                case "Vegetable":
                    food = new Vegetable(int.Parse(foodTokens[1]));
                    break;
            }

            animal.ProduceSound();
            if (!animal.TryFeed(food.GetType()))
            {
                Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                animal.Feed(food);
            }

            animals.Add(animal);
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}

