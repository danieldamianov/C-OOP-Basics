using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Worker
{
    public double energyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            ValidateEnergyOutput(value);
            this.energyOutput = value;
        }
    }

    public virtual string TypeProvider { get; set; }

    protected Provider(string Id, double EnergyOutput) : base(Id)
    {
        ValidateEnergyOutput(EnergyOutput);
        this.energyOutput = EnergyOutput;
    }

    private void ValidateEnergyOutput(double energyOutput)
    {
        if (energyOutput < 0 || energyOutput > 10_000)
        {
            throw new ArgumentOutOfRangeException("EnergyOutput");
        }
    }

    public override string ToString()
    {
        return $"Energy Output: {this.energyOutput}";
    }
}

