﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {

        }

        public override string ToString() ////////////////// check AGAIN
        {
            return $"    Animal type: Pig - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
