using System;

public class Car
{
    private const int MaximumTankCapacity = 160;
    private int hp;

    public int Hp
    {
        get { return hp; }
        private set { hp = value; }
    }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return fuelAmount; }
        set
        {
            if (value > 160)
            {
                fuelAmount = 160;
            }
            else
            {
                fuelAmount = value;
            }
        }
    }

    private Tyre tyre;

    public double TyreDegregation => this.tyre.Degradation;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.tyre = tyre;
    }

    public void CheckForOverfueling()
    {
        if (this.FuelAmount > MaximumTankCapacity)
        {
            this.FuelAmount = MaximumTankCapacity;
        }
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.tyre = tyre;
    }

    public void DegradateTyres()
    {
        this.tyre.Degradate();
    }

    public string GetTyreType()
    {
        return this.tyre.Name;
    }
}

