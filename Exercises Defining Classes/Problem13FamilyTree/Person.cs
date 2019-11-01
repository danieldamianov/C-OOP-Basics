public class Person
{
    public string Name { get; set; }

    public string DateOfBirth { get; set; }

    public Person(string name , string date)
    {
        this.Name = name;
        this.DateOfBirth = date;
    }

    public Person()
    {

    }

    public override string ToString()
    {
        return $"{this.Name} {this.DateOfBirth}";
    }
}