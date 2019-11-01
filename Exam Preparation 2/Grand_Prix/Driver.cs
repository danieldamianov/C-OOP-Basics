public abstract class Driver
{
    public int orderOfInput;
    public bool isInRace;
    public string ReasonForDNF { get; set; }
    private string name;

    public string Name
    {
        get { return name; }
    }

    private double totalTime;

    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    private Car Car;

    private Driver(string name)
    {
        this.isInRace = true;
        this.name = name;
        this.TotalTime = 0;
        this.ReasonForDNF = "";
    }

    protected Driver(string name, int hp, double fuelAmount, double tyreHardness) : this(name)
    {
        this.Car = new Car(hp, fuelAmount, new HardTyre(tyreHardness));
    }

    protected Driver(string name, int hp, double fuelAmount, double tyreHardness, double tyreGrip) : this(name)
    {
        this.Car = new Car(hp, fuelAmount, new UltrasoftTyre(tyreHardness, tyreGrip));
    }

    public abstract double FuelConsumptionPerKm { get; }

    public virtual double Speed
    {
        get
        {
            return (this.Car.Hp + this.Car.TyreDegregation) / this.Car.FuelAmount; 
        }
        
    }
    public void DecreaseCarFuelAmount(double value) // CHECK ABOUT NEGATIVE!!!
    {
        this.Car.FuelAmount -= value;
        if (this.Car.FuelAmount < 0)
        {
            throw new DidNotFinishedDriverExcepton("Out of fuel");
        }
    }

    public void IncreaseCarFuelAmount(double value) // CHECK ABOUT OVERFUELING!!!
    {
        this.Car.FuelAmount += value;
        this.Car.CheckForOverfueling();
    }

    public void ChangeCarsTyres(Tyre tyre)
    {
        this.Car.ChangeTyres(tyre);
    }

    public void DegradateTyres()
    {
        this.Car.DegradateTyres();
    }

    public void OutOFTheRace(string reason)
    {
        this.isInRace = false;
        this.TotalTime = int.MaxValue;
        this.ReasonForDNF = reason;
    }

    public string GetTyreType()
    {
        return this.Car.GetTyreType();
    }
}

