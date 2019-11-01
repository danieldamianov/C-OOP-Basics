namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic; // CHECK IF THEY WANT DICITONARY !!!

    public interface IHotel
    {
        void Accommodate(IAnimal animal);

        void Adopt(string animalName, string owner);

        IReadOnlyDictionary<string, IAnimal> Animals { get; }
    }
}
