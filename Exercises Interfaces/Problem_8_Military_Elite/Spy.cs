using System;
using System.Collections.Generic;
using System.Text;

public sealed class Spy : Soldier, ISpy
{
    public int CodeNumber { get; }

    public Spy(string id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
            .AppendLine($"Code Number: {this.CodeNumber}");
        return stringBuilder.ToString().TrimEnd();
    }
}

