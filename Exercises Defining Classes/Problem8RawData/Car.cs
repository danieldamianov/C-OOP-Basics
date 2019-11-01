using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public Tyre[] tyres; 

    public Car(string model, int engineSpeed, int enginePower , int cargoWeight , string cargoType , double tirePressure1 , int tireAge1, double tirePressure2, int tireAge2 , double tirePressure3, int tireAge3, double tirePressure4, int tireAge4)
    {
        this.Model = model;
        this.Engine = new Engine(engineSpeed, enginePower);
        this.Cargo = new Cargo(cargoWeight, cargoType);
        this.tyres = new Tyre[4];
        this.tyres[0] = new Tyre(tirePressure1, tireAge1);
        this.tyres[1] = new Tyre(tirePressure2, tireAge2);
        this.tyres[2] = new Tyre(tirePressure3, tireAge3);
        this.tyres[3] = new Tyre(tirePressure4, tireAge4);
    }

    public override string ToString()
    {
        return $"{this.Model}";
    }
}

