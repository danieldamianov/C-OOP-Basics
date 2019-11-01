using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip() : base()
        {

        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            Animal animalAsAnimal = animal as Animal;
            try
            {
                animalAsAnimal.Chip(procedureTime);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(string.Format(ex.Message,animal.Name));
            }
            this.procedureHistory.Add(animalAsAnimal);
        }
    }
}
