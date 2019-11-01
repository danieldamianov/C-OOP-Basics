using System;
using System.Collections.Generic;
using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string Id, double EnergyOutput) : base(Id, EnergyOutput)
    {
    }

    public override string TypeProvider => "Solar";
}

