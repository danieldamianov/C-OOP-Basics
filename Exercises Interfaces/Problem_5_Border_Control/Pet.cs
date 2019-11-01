public class Pet : IBirthDayable , INamable
{
    public string Name { get; }
    public string BirthDay { get; }

    public Pet(string name , string date)
    {
        this.Name = name;
        this.BirthDay = date;
    }
}

