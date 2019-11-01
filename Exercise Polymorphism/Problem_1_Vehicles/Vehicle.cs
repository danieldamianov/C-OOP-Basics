using System;

public abstract class Vehicle
{
    protected double fuelQuantity;
    protected double fuelConsumptionPerKm;
    protected double tankCapacity;

    public abstract string Drive(double distance);

    public abstract void Refuel(double fuel);

    protected void CheckForNegativeFuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
    }

}

