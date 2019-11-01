using AnimalCentre.Models.Procedures;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            AnimalCentre animalCentre = new AnimalCentre();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(animalCentre.RegisterAnimal
                                (tokens[1],tokens[2],int.Parse(tokens[3]),int.Parse(tokens[4]),int.Parse(tokens[5])));
                            break;
                        case "Chip":
                            Console.WriteLine(animalCentre.Chip(tokens[1],int.Parse(tokens[2])));
                            break;
                        case "Vaccinate":
                            Console.WriteLine(animalCentre.Vaccinate(tokens[1], int.Parse(tokens[2])));
                            break;
                        case "Fitness":
                            Console.WriteLine(animalCentre.Fitness(tokens[1], int.Parse(tokens[2])));
                            break;
                        case "Play":
                            Console.WriteLine(animalCentre.Play(tokens[1], int.Parse(tokens[2])));
                            break;
                        case "DentalCare":
                            Console.WriteLine(animalCentre.DentalCare(tokens[1], int.Parse(tokens[2])));
                            break;
                        case "NailTrim":
                            Console.WriteLine(animalCentre.NailTrim(tokens[1], int.Parse(tokens[2])));
                            break;
                        case "Adopt":
                            Console.WriteLine(animalCentre.Adopt(tokens[1], tokens[2]));
                            break;
                        case "History":
                            if (animalCentre.History(tokens[1]) != "")
                            {
                                Console.WriteLine(animalCentre.History(tokens[1])); 
                            }
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                }
            }
            if (animalCentre.GetOwnersInfo() != "")
            {
                Console.WriteLine(animalCentre.GetOwnersInfo()); 
            }
        }
    }
}
