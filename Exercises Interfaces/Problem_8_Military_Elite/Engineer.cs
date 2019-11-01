using System;
using System.Collections.Generic;
using System.Text;

public sealed class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; }

    public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary,corps)
    {
        this.Repairs = new List<Repair>();
    }

    public void AddRepair(Repair repair)
    {
        this.Repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());
        stringBuilder.AppendLine($"Corps: {this.Corps}")
            .AppendLine("Repairs:");
        foreach (var repair in this.Repairs)
        {
            stringBuilder.AppendLine($"  {repair}");
        }
        return stringBuilder.ToString().TrimEnd();
    }
}

