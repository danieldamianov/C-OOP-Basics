using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                this.energy = value;
            }
        }

        public int ProcedureTime { get; private set; }

        public string Owner { get; private set; }

        public bool IsAdopt { get; private set; }

        public bool IsChipped { get; private set; }

        public bool IsVaccinated { get; private set; }

        private void CheckForProcedureTime(int procedureTime)
        {
            if (this.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            this.ProcedureTime -= procedureTime;
        }

        public void Chip(int procedureTime)
        {
            this.CheckForProcedureTime(procedureTime);
            if (this.IsChipped)
            {
                throw new ArgumentException("{0} is already chipped"); // THEN ADD NAME
            }
            this.Happiness -= 5;
            this.IsChipped = true;
        }

        public void DentalCare(int procedureTime)
        {
            this.CheckForProcedureTime(procedureTime);
            this.Happiness += 12;
            this.Energy += 10;
        }

        public void Fitness(int procedureTime)
        {
            this.CheckForProcedureTime(procedureTime);
            this.Happiness -= 3;
            this.Energy += 10;
        }

        public void NailTrim(int procedureTime)
        {
            this.CheckForProcedureTime(procedureTime);
            this.Happiness -= 7;
        }

        public void Play(int procedureTime)
        {
            this.CheckForProcedureTime(procedureTime);
            this.Happiness += 12;
            this.Energy -= 6;
        }

        public void Vaccinate(int procedureTime)
        {
            this.CheckForProcedureTime(procedureTime);
            this.Energy -= 8;
            this.IsVaccinated = true;
        }

        public void Adopt(string owner)
        {
            this.IsAdopt = true;
            this.Owner = owner;
        }
    }
}
