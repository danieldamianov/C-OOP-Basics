using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        public DentalCare() : base()
        {

        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            Animal animalAsAnimal = animal as Animal;
            animalAsAnimal.DentalCare(procedureTime);
            this.procedureHistory.Add(animalAsAnimal);
        }
    }
}
