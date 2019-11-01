using System;
using System.Collections.Generic;
using System.Text;

public class StreetExtraordinaire : Cat
{
    public int Decibels { get; set; }

    public StreetExtraordinaire(string breed, string name, int decibels)
    {
        this.Breed = breed;
        this.Name = name;
        this.Decibels = decibels;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.Decibels}";
    }
}
