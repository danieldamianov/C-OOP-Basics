using System;

public class Program
{
    static void Main(string[] args)
    {
        SmarthPhone smarthPhone = new SmarthPhone();
        foreach (var number in Console.ReadLine().Split())
        {
            try
            {
                smarthPhone.Call(number);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var url in Console.ReadLine().Split())
        {
            try
            {
                smarthPhone.Browse(url);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

