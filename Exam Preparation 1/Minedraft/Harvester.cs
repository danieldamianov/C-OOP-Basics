using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Worker
{
    public double oreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            ValidateOreOutput(value);
            this.oreOutput = value;
        }
    }
    public double energyRequirement
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            ValidateEnergyRequirement(value);
            this.energyRequirement = value;
        }
    }

    public virtual string TypeHarvester { get; set; }

    protected Harvester(string id, double OreOutput, double EnergyRequirement):base(id)
    {
        ValidateOreOutput(OreOutput);
        ValidateEnergyRequirement(EnergyRequirement);
        this.oreOutput = OreOutput;
        this.energyRequirement = EnergyRequirement;
    }

    private void ValidateEnergyRequirement(double energyRequirement)
    {
        if (energyRequirement < 0 || energyRequirement > 20_000)
        {
            throw new ArgumentOutOfRangeException("EnergyRequirement");
        }
    }

    private void ValidateOreOutput(double oreOutput)
    {
        if (oreOutput < 0)
        {
            throw new ArgumentOutOfRangeException("OreOutput");
        }
    }

    public override string ToString()
    {
        return $"Ore Output: {this.oreOutput}" + Environment.NewLine + $"Energy Requirement: {this.energyRequirement}";
    }
}

