using System;
using System.Collections.Generic;
using System.Text;

public class Tyre
{
    public double TirePressure { get; set; }
    public int TireAge { get; set; }
    
    public Tyre(double tirePressure , int tireAge)
    {
        this.TirePressure = tirePressure;
        this.TireAge = tireAge;
    }
}
