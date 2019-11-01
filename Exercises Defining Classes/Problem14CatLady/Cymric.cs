using System;
using System.Collections.Generic;
using System.Text;

public class Cymric : Cat
{
    public double FurLength { get; set; }

    public Cymric(string breed, string name, double furLength)
    {
        this.Breed = breed;
        this.Name = name;
        this.FurLength = furLength;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.FurLength:f2}"; 
    }
}
