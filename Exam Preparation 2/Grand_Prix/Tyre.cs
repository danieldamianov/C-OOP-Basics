using System;

public abstract class Tyre
{
    public abstract string Name { get; }

    private double hardness;

    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    private double degradation;
            
    public double Degradation
    {
        get { return this.degradation; }
        protected set { this.degradation = value; }
    }

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public virtual void Degradate()
    {
        this.Degradation -= this.Hardness;
        if (this.Degradation < 0)
        {
            throw new DidNotFinishedDriverExcepton("Blown Tyre"); 
        }
    }
}

