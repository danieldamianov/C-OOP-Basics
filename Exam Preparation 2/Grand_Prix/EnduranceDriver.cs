public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, int hp, double fuelAmount, double tyreHardness)
        : base(name, hp, fuelAmount, tyreHardness)
    {
    }

    public EnduranceDriver(string name, int hp, double fuelAmount, double tyreHardness, double tyreGrip)
        : base(name, hp, fuelAmount, tyreHardness, tyreGrip)
    {
    }

    public override double FuelConsumptionPerKm => 1.5;
}

