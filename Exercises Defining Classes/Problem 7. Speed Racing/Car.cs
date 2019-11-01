using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }

    private double FuelAmount { get; set; }

    private double FuelConsumptionFor1km { get; set; }

    private double DistanceTraveled { get; set; }

    public Car(string model , double fuelAmount , double fuelConsumptionFor1km)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionFor1km = fuelConsumptionFor1km;
        this.DistanceTraveled = 0;
    }

    private bool CanMove(double distance)
    {
        if (distance * this.FuelConsumptionFor1km <= FuelAmount)
        {
            return true;
        }
        return false;
    }

    public void Move(double distance)
    {
        if (CanMove(distance) == false)
        {
            Console.WriteLine("Insufficient fuel for the drive");
            return;
        }

        this.DistanceTraveled += distance;
        this.FuelAmount -= distance * this.FuelConsumptionFor1km;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:F2} {this.DistanceTraveled}";
    }
}

