using System;
using System.Collections.Generic;
using System.Text;

public class Pokemon
{
    public string Name { get; set; }

    public string Element { get; set; }

    public double Health { get; set; }

    public Pokemon(string name, string element , double health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }
}
