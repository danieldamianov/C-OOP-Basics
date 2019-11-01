using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Animal
{
    public Dog(string name , int age , string gender):base(name,age,gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Animal
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow meow");
    }
}

public class Frog : Animal
{
    public Frog(string name, int age, string gender) : base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Ribbit");
    }
}

public class Kitten : Cat
{
    public Kitten(string name, int age, string gender) : base(name, age, gender)
    {
        this.gender = "Female";
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}

public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {
        this.gender = "Male";
    }

    public override void ProduceSound()
    {
        Console.WriteLine("MEOW");
    }
}

