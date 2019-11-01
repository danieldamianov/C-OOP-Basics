using System;
using System.Collections.Generic;
using System.Text;

public class Siamese : Cat
{
    public int EarSize { get; set; }

    public Siamese(string breed, string name, int earSize)
    {
        this.Breed = breed;
        this.Name = name;
        this.EarSize = earSize;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.EarSize}";
    }
}
