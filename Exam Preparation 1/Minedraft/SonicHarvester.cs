using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double OreOutput, double EnergyRequirement, int SonicFactor) : base(id, OreOutput, EnergyRequirement)
    {
        this.energyRequirement /= SonicFactor;
        this.sonicFactor = SonicFactor;
    }
    private int sonicFactor { get; set; }

    public override string TypeHarvester => "Sonic";
}

