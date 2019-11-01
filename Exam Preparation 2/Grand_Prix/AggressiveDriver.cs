public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, int hp, double fuelAmount, double tyreHardness) : base(name, hp, fuelAmount, tyreHardness)
    {
    }

    public AggressiveDriver(string name, int hp, double fuelAmount, double tyreHardness, double tyreGrip) : base(name, hp, fuelAmount,tyreHardness, tyreGrip)
    {
    }

    public override double FuelConsumptionPerKm => 2.7;
    public override double Speed
    {
        get
        {
            return base.Speed * 1.3;
        }
    }
}

