﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {

        }

        public override string ToString() ////////////////// check AGAIN
        {
            return $"    Animal type: Cat - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
