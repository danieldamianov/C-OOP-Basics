using System;

public class Rectangle : IDrawable
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public Rectangle(int width , int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public void Draw()
    {
        Rectangle.DrawLine(this.Width, '*', '*');
        for (int i = 0; i < this.Height - 2; i++)
        {
            Rectangle.DrawLine(this.Width, '*', ' ');
        }
        Rectangle.DrawLine(this.Width, '*', '*');
    }

    private static void DrawLine(double length , char startAndEnd , char middle)
    {
        Console.Write(startAndEnd);
        for (int i = 0; i < length - 2; i++)
        {
            Console.Write(middle);
        }
        Console.WriteLine(startAndEnd);
    }
}

