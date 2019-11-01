using System;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] studentTokens = Console.ReadLine().Split();
            Student student = new Student(studentTokens[0],studentTokens[1],studentTokens[2]);

            string[] workerTokens = Console.ReadLine().Split();
            Worker worker = new Worker(workerTokens[0], workerTokens[1], decimal.Parse(workerTokens[2]), decimal.Parse(workerTokens[3]));

            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

