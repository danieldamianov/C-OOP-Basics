using System;
using System.Collections.Generic;
using System.Text;

public sealed class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<Private> privates;
                
    public IReadOnlyCollection<Private> Privates
    {
        get { return privates.AsReadOnly(); }
    }


    public LeutenantGeneral(string id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName ,salary)
    {
        privates = new List<Private>();
    }

    public void AddPrivate(Private privateObj)
    {
        this.privates.Add(privateObj);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());
        stringBuilder.AppendLine($"Privates:");
        foreach (var privateObj in this.privates)
        {
            stringBuilder.AppendLine($"  {privateObj}");
        }
        return stringBuilder.ToString().TrimEnd();
    }
}

