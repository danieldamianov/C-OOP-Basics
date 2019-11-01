using System;
using System.Collections.Generic;
using System.Text;

public sealed class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> Missions { get; }

    public Commando(string id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<Mission>();
    }

    public void AddMission(Mission mission)
    {
        ValidateMissionState(mission.State);
        this.Missions.Add(mission);
    }

    private static void ValidateMissionState(string state)
    {
        if (state != "inProgress" && state != "Finished")
        {
            throw new ArgumentException();
        }
    }

    public void CompleteMission() //?????????????????????
    {
        
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());
        stringBuilder.AppendLine($"Corps: {this.Corps}")
            .AppendLine("Missions:");
        foreach (var mission in this.Missions)
        {
            stringBuilder.AppendLine($"  {mission}");
        }
        return stringBuilder.ToString().TrimEnd();
    }
}

