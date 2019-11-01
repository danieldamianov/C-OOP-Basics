using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string[] foods = Console.ReadLine().Split(' ');
        int mood = 0;
        foreach (var food in foods.Select(x => x.ToLower()).ToArray())
        {
            int coef;
            switch (food)
            {
                case "cram":
                    coef = 2;
                    break;
                case "lembas":
                    coef = 3;
                    break;
                case "apple":
                    coef = 1;
                    break;
                case "melon":
                    coef = 1;
                    break;
                case "honeycake":
                    coef = 5;
                    break;
                case "mushrooms":
                    coef = -10;
                    break;
                default:
                    coef = -1;
                    break;
            }
            mood += coef;
        }
        Console.WriteLine(mood);
        if (mood < -5)
        {
            Console.WriteLine("Angry");
        }
        else if(mood <= 0)
        {
            Console.WriteLine("Sad");
        }
        else if (mood <= 15)
        {
            Console.WriteLine("Happy");
        }
        else
        {
            Console.WriteLine("JavaScript");
        }
    }
}

