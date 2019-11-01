using System;
using System.Linq;

public class SmarthPhone : IBrowsable, ICallable
{
    public void Browse(string url)
    {
        ValidateUrl(url);
        Console.WriteLine($"Browsing: {url}!");
    }

    public void Call(string number)
    {
        ValidateNumber(number);
        Console.WriteLine($"Calling... {number}");
    }

    private static void ValidateNumber(string number)
    {
        if (number.Any(x => !char.IsDigit(x)))
        {
            throw new ArgumentException("Invalid number!");
        }
    }

    private static void ValidateUrl(string url)
    {
        if (url.Any(x => char.IsDigit(x)))
        {
            throw new ArgumentException("Invalid URL!");
        }
    }
}

