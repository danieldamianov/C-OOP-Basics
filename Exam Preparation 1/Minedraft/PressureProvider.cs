using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string Id, double EnergyOutput) : base(Id, EnergyOutput * 1.5)
    {
       
    }

    public override string TypeProvider => "Pressure";
}

