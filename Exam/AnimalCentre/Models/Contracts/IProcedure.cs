namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IProcedure
    {
        string History();

        void DoService(IAnimal animal, int procedureTime);

        IReadOnlyCollection<IAnimal> ProcedureHistory { get; }
    }
}
