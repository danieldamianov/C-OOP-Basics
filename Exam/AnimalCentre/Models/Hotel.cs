using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (this.animals.ContainsKey(animal.Name) == true)
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (this.animals.ContainsKey(animalName) == false)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            IAnimal animal = this.animals[animalName];
            ((Animal)animal).Adopt(owner);
            this.animals.Remove(animalName);
        }
    }
}
