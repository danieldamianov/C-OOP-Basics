using System;
using System.Collections.Generic;
using System.Text;

public class Family
{
    public Person MainPerson { get; set; }

    public List<Person> Children { get; set; }

    public List<Person> Parents { get; set; }

    public Family()
    {
        this.MainPerson = new Person();
        this.Children = new List<Person>();
        this.Parents = new List<Person>();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.MainPerson.ToString());
        sb.AppendLine("Parents:");
        foreach (var par in this.Parents)
        {
            sb.AppendLine(par.ToString());
        }
        sb.AppendLine("Children:");
        foreach (var ch in this.Children)
        {
            sb.AppendLine(ch.ToString());
        }

        return sb.ToString().Trim();
    }
}
