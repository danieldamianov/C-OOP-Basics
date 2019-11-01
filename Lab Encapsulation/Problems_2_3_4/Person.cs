using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private const int MINSALARY = 460;
    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            this.firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            this.lastName = value;
        }
    }

    public string FullName => $"{this.firstName} {this.lastName}";

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < MINSALARY)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            this.salary = value;
        }
    }

    public void IncreaseSalary(decimal percentage)
    {
        percentage = this.age < 30 ? percentage / 2 : percentage;
        this.salary = this.salary * ((100m + percentage) / 100m);
    }

    public Person(string firstName, string secondName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = secondName;
        this.Age = age;
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{FullName} receives {this.salary:f2} leva.";
    }
}
