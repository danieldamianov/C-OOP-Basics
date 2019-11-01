using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double capacity)
    {
        this.tankCapacity = capacity;
        if (fuelQuantity > this.tankCapacity)
        {
            fuelQuantity = 0;
        }
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumptionPerKm = fuelConsumption + 0.9d;
    }

    public sealed override string Drive(double distance)
    {
        if (distance > this.MaximumKilometersThatCanBeDriven())
        {
            return "Car needs refueling";
        }
        this.fuelQuantity -= distance * this.fuelConsumptionPerKm;
        return $"Car travelled {distance} km";
    }

    public sealed override void Refuel(double fuel)
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

    private double MaximumKilometersThatCanBeDriven()
    {
        return this.fuelQuantity / this.fuelConsumptionPerKm;
    }

    public sealed override string ToString()
    {
        return $"Car: {this.fuelQuantity:f2}";
    }
}

