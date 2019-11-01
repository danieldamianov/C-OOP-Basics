using AnimalCentre.Models;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre
{
    public class AnimalCentre
    {
        Hotel hotel;
        Chip chip;
        DentalCare dentalCare;
        Fitness fitness;
        NailTrim nailTrim;
        Play play;
        Vaccinate vaccinate;
        Dictionary<string, List<string>> owners;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.chip = new Chip();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
            this.nailTrim = new NailTrim();
            this.play = new Play();
            this.vaccinate = new Vaccinate();
            this.owners = new Dictionary<string, List<string>>();
        }

        private void CheckIfAnimalExistsInHotel(string name)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }

        private IAnimal GetAnimalFromHotel(string name)
        {
            this.CheckIfAnimalExistsInHotel(name);
            return this.hotel.Animals[name];
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal;
            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new ArgumentException("Invalid Type Animal");
            }
            this.hotel.Accommodate(animal);
            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            this.chip.DoService(this.GetAnimalFromHotel(name), procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            this.vaccinate.DoService(this.GetAnimalFromHotel(name), procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            this.fitness.DoService(this.GetAnimalFromHotel(name), procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            this.play.DoService(this.GetAnimalFromHotel(name), procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            this.dentalCare.DoService(this.GetAnimalFromHotel(name), procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            this.nailTrim.DoService(this.GetAnimalFromHotel(name), procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            bool isChipped = this.GetAnimalFromHotel(animalName).IsChipped;
            this.hotel.Adopt(animalName, owner);
            if (this.owners.ContainsKey(owner) == false)
            {
                this.owners.Add(owner, new List<string>());
            }
            this.owners[owner].Add(animalName);
            return isChipped ? $"{owner} adopted animal with chip" : $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            switch (type)
            {
                case "Chip":
                    return this.chip.History();
                case "DentalCare":
                    return this.dentalCare.History();
                case "Fitness":
                    return this.fitness.History();
                case "NailTrim":
                    return this.nailTrim.History();
                case "Play":
                    return this.play.History();
                case "Vaccinate":
                    return this.vaccinate.History();
            }
            return null;
        }

        public string GetOwnersInfo()
        {
            if (this.owners.Count == 0)
            {
                return "";
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var owner in this.owners.OrderBy(owner => owner.Key))
            {
                stringBuilder.AppendLine($"--Owner: {owner.Key}");
                stringBuilder.AppendLine($"    - Adopted animals: {string.Join(" ",owner.Value)}");
            }
            return stringBuilder.ToString().Trim();
        }

    }
}
