using System;

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("width", "The width cannot be a negative number!");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("height", "The height cannot be a negative number!");
            }

            this.height = value;
        }
    }

    public override double CalculateArea()
    {
        return width * height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * width + 2 * height;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}

