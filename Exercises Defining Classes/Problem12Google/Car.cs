public class Car
{
    public string Model { get; set; }

    public int Speed { get; set; }

    public Car(string model , int speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public Car()
    {
        this.Model = "";
        this.Speed = -1;
    }

    public override string ToString()
    {
        if (this.Speed != -1 && this.Model != "")
        {
            return $"{this.Model} {this.Speed}";
        }
        else
        {
            return null;
        }
    }
}