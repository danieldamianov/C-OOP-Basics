using System;
using System.Collections.Generic;
using System.Text;

public class Animal
{
    protected string name;
    protected int age;
    protected string gender;

    protected Animal(string name , int age , string gender)
    {
        ValidateAge(age);

        this.name = name;
        this.age = age;
        this.gender = gender;
    }

    private void ValidateAge(int age)
    {
        if (age <= 0)
        {
            throw new ArgumentException("Invalid input!");
        }
    }

    public virtual void ProduceSound()
    {
        Console.WriteLine("");
    }

    public override string ToString()
    {
        return $"{this.name} {this.age} {this.gender}";
    }
}

