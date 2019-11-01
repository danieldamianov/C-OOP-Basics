using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public string Corps { get; }

    protected SpecialisedSoldier(string id , string firstName , string lastName , decimal salary , string corps)
        :base(id,firstName,lastName,salary)
    {
        ValidateCorps(corps);
        this.Corps = corps;
    }

    private static void ValidateCorps(string corps)
    {
        if (corps != "Airforces" && corps != "Marines")
        {
            throw new ArgumentException();
        }
    }
}

