using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson , IBirthable , IIdentifiable
{
    public string Name { get; }

    public int Age { get; }

    public string Id { get; }

    public string Birthdate { get; }

    public Citizen(string name , int age , string id ,string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthDate;
    }
}

