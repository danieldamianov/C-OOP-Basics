using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private int age;

    public int Age
    {
        get { return age; }
    }

    private string firstName;

    public string FirstName
    {
        get { return firstName; }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
    }

    public string FullName => $"{this.firstName} {this.lastName}";

    public Person(string firstName , string secondName , int age)
    {
        this.firstName = firstName;
        this.lastName = secondName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.FullName} is {this.age} years old.";
    }
}
