using System;

public class Circle : Shape
{
    private double radius;

    public double Radius
    {
        get
        {
            return this.radius;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("radius", "The radius cannot be a negative number!");
            }

            this.radius = value;
        }
    }

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * this.radius * this.radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.radius;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}

