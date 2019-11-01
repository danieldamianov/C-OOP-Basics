using System;

public class UltrasoftTyre : Tyre 
{
    private double grip;

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Grip = grip;
    }

    public override string Name => "Ultrasoft";

    public override void Degradate()
    {
        this.Degradation -= (this.Hardness + this.Grip);
        if (this.Degradation < 30)
        {
            throw new DidNotFinishedDriverExcepton("Blown Tyre");
        }
    }
}

