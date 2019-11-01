using System;

public class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if (input == "Square")
        {
            int side = int.Parse(Console.ReadLine());
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side + 2; j++)
                {
                    if (j == 0 || j == side + 1)
                    {
                        Console.Write('|');
                    }
                    else if(i == 0 || i == side - 1)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width + 2; j++)
                {
                    if (j == 0 || j == width + 1)
                    {
                        Console.Write('|');
                    }
                    else if (i == 0 || i == height - 1)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
