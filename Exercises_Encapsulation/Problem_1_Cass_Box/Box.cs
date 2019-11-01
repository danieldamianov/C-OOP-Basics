using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine($"Length cannot be zero or negative.");
                Environment.Exit(0);
            }
            else
            {
                this.length = value;
            }
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine($"Width cannot be zero or negative.");
                Environment.Exit(0);
            }
            else
            {
                this.width = value;
            }
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine($"Height cannot be zero or negative.");
                Environment.Exit(0);
            }
            else
            {
                this.height = value;
            }
        }
    }


    public Box(double length , double width , double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double GetSurfaceArea()
    {
        return 2 * (width * length + width * height + length * height);
    }
    public double GetVolume()
    {
        return width * length * height;
    }
    public double GetLateralSurfaceArea()
    {
        return 2 * (length * height + width * height);
    }

    public override string ToString()
    {
        return $"Surface Area - {this.GetSurfaceArea():f2}\nLateral Surface Area - {this.GetLateralSurfaceArea():f2}\nVolume - {this.GetVolume():f2}";
    }
}

