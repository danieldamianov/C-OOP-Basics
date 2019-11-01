using System;

public class Truck : Vehicle
{ 
    public Truck(double fuelQuantity, double fuelConsumption, double capacity)
    {
        this.tankCapacity = capacity;
        if (fuelQuantity > this.tankCapacity)
        {
            fuelQuantity = 0;
        }
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumptionPerKm = fuelConsumption + 1.6d;
    }

    public sealed override string Drive(double distance)
    {
        if (distance > this.MaximumKilometersThatCanBeDriven())
        {
            return "Truck needs refueling";
        }
        this.fuelQuantity -= distance * this.fuelConsumptionPerKm;
        return $"Truck travelled {distance} km";
    }

    public sealed override void Refuel(double fuel)
    {
        CheckForNegativeFuel(fuel);
        if (FuelFills(fuel) == false)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            return;
        }
        this.fuelQuantity += fuel * (95d / 100d);
    }

    private double MaximumKilometersThatCanBeDriven()
    {
        return this.fuelQuantity / this.fuelConsumptionPerKm;
    }

    private bool FuelFills(double fuel)
    {
        return this.fuelQuantity + fuel <= this.tankCapacity;
    }

    public sealed override string ToString()
    {
        return $"Truck: {this.fuelQuantity:f2}";
    }
}

