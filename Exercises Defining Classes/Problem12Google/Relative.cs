using System;

public class Relative
{
    public string Name { get; set; }

    public string DateOfBirth { get; set; }

    public Relative(string name , string dateOfBirth)
    {
        this.Name = name;
        this.DateOfBirth = dateOfBirth;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.DateOfBirth}";
    }
}