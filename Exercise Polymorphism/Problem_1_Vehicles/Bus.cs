using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double capacity)
    {
        this.tankCapacity = capacity;
        if (fuelQuantity > this.tankCapacity)
        {
            fuelQuantity = 0;
        }
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumptionPerKm = fuelConsumption;
    }

    public sealed override string Drive(double distance)
    { 
        if (distance > this.MaximumKilometersThatCanBeDrivenWithAirCond())
        {
            return "Bus needs refueling";
        }
        this.fuelQuantity -= distance * (this.fuelConsumptionPerKm + 1.4);
        return $"Bus travelled {distance} km";
    }

    public string DriveEmpty(double distance)
    {
        if (distance > this.MaximumKilometersThatCanBeDriven())
        {
            return "Bus needs refueling";
        }
        this.fuelQuantity -= distance * this.fuelConsumptionPerKm;
        return $"Bus travelled {distance} km";
    }

    private double MaximumKilometersThatCanBeDriven()
    {
        return this.fuelQuantity / this.fuelConsumptionPerKm;
    }

    private double MaximumKilometersThatCanBeDrivenWithAirCond()
    {
        return this.fuelQuantity / (this.fuelConsumptionPerKm + 1.4);
    }

    public override void Refuel(double fuel)
    {
        CheckForNegativeFuel(fuel);
        if (FuelFills(fuel) == false)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            return;
        }
        this.fuelQuantity += fuel;
    }

    private bool FuelFills(double fuel)
    {
        return this.fuelQuantity + fuel <= this.tankCapacity;
    }

    public sealed override string ToString()
    {
        return $"Bus: {this.fuelQuantity:f2}";
    }
}


