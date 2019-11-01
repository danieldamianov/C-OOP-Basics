public class Ferari : IDrivable
{
    private string driver;

    private string model;

    private Ferari()
    {
        this.model = "488-Spider";
    }

    public Ferari(string driver) : this()
    {
        this.driver = driver;
    }

    public string Brake()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.model}/{this.Brake()}/{this.Gas()}/{this.driver}";
    }
}

