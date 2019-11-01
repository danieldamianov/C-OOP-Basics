public class Citizent : IIdentifiable , IBirthDayable , IBuyer
{
    private int Age;
    public string Name { get; }
    public string Id { get; set; }
    public string BirthDay { get; }
    public int Food { get; private set; }

    public Citizent(string name , int age , string id , string date)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDay = date;
        this.Food = 0;
    }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

