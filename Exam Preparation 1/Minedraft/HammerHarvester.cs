using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double OreOutput, double EnergyRequirement) : base(id, OreOutput * 3, EnergyRequirement * 2)
    {
    }

    public override string TypeHarvester => "Hammer";
}

