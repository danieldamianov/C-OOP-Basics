using System;
using System.Collections.Generic;
using System.Text;

public abstract class Soldier : ISoldier
{
    public string Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    protected Soldier(string id , string firstName , string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}

