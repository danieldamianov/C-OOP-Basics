using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    List<Harvester> harvesters = new List<Harvester>();
    List<Provider> providers = new List<Provider>();

    private string mode = "fullmode"; // fullmode, halfmode, energymode
    private double currentEnergyProvided = 0;
    private double totalOre = 0;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            if (arguments.Count == 4)
            {
                harvesters.Add(new HammerHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3])));
            }
            else
            {
                harvesters.Add(new SonicHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]), int.Parse(arguments[4])));
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return $"Harvester is not registered, because of it's {ex.ParamName}";
        }
        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            if (arguments[0] == "Solar")
            {
                providers.Add(new SolarProvider(arguments[1], double.Parse(arguments[2])));
            }
            else
            {
                providers.Add(new PressureProvider(arguments[1], double.Parse(arguments[2])));
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return $"Provider is not registered, because of it's {ex.ParamName}";
        }
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }
    public string Day()
    {
        string result = string.Empty;
        currentEnergyProvided += GetCurrentDayEnergy();
        if (currentEnergyProvided < GetCurrentDayEnergyRequirement())
        {
            result = "A day has passed.";
            result += Environment.NewLine;
            result += $"Energy Provided: {GetCurrentDayEnergy()}";
            result += Environment.NewLine;
            result += $"Plumbus Ore Mined: 0";
            return result;
        }
        currentEnergyProvided -= GetCurrentDayEnergyRequirement();
        totalOre += GetCurrentDayOre();
        result = "A day has passed.";
        result += Environment.NewLine;
        result += $"Energy Provided: {GetCurrentDayEnergy()}";
        result += Environment.NewLine;
        result += $"Plumbus Ore Mined: {GetCurrentDayOre()}";
        return result;
    }

    private double GetCurrentDayOre()
    {
        switch (this.mode)
        {
            case "fullmode":
                return this.harvesters.Sum(x => x.oreOutput);
            case "halfmode":
                return this.harvesters.Sum(x => x.oreOutput) * (50 / 100d);
            case "energymode":
                return 0;
            default:
                throw new NotImplementedException();
        }
    }

    private double GetCurrentDayEnergyRequirement()
    {
        switch (this.mode)
        {
            case "fullmode":
                return this.harvesters.Sum(x => x.energyRequirement);
            case "halfmode":
                return this.harvesters.Sum(x => x.energyRequirement) * (60d / 100d);
            case "energymode":
                return 0;
            default:
                throw new NotImplementedException();
        }
    }

    private double GetCurrentDayEnergy()
    {
        return this.providers.Sum(x => x.energyOutput);
    }

    public string Mode(List<string> arguments)
    {
        switch (arguments[0])
        {
            case "Full":
                this.mode = "fullmode";
                break;
            case "Half":
                this.mode = "halfmode";
                break;
            case "Energy":
                this.mode = "energymode";
                break;
        }
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }
    public string Check(List<string> arguments)
    {
        var virtualHarvester = harvesters.SingleOrDefault(x => x.id == arguments[0]);
        var virtualProvider = providers.SingleOrDefault(x => x.id == arguments[0]);
        if (virtualHarvester != null)
        {
            return $"{virtualHarvester.TypeHarvester} Harvester - {virtualHarvester.id}" + Environment.NewLine + virtualHarvester.ToString();
        }
        if (virtualProvider != null)
        {
            return $"{virtualProvider.TypeProvider} Provider - {virtualProvider.id}" + Environment.NewLine + virtualProvider.ToString();
        }

        return $"No element found with id - {arguments[0]}";
    }
    public string ShutDown()
    {
        return "System Shutdown"
            + Environment.NewLine
            + $"Total Energy Stored: {currentEnergyProvided}" 
            + Environment.NewLine 
            + $"Total Mined Plumbus Ore: {totalOre}";
    }

}

