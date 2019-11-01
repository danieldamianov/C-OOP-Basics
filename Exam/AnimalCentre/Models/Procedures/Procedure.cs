using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<Animal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<Animal>();
        }

        public IReadOnlyCollection<IAnimal> ProcedureHistory => this.procedureHistory.AsReadOnly();

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.GetType().Name);
            foreach (var animal in this.procedureHistory.OrderBy(x => x.Name))
            {
                stringBuilder.AppendLine(animal.ToString());
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
