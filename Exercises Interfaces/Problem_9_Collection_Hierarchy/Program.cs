using System;

public class Program
{
    static void Main(string[] args)
    {
        var addCollection = new AddCollection();
        var addRemoveCollection = new AddRemoveCollection();
        var myList = new MyList();
        var addItems = Console.ReadLine().Split();
        foreach (var item in addItems)
        {
            Console.Write(addCollection.Add(item) + " ");
        }
        Console.WriteLine();
        foreach (var item in addItems)
        {
            Console.Write(addRemoveCollection.Add(item) + " ");
        }
        Console.WriteLine();
        foreach (var item in addItems)
        {
            Console.Write(myList.Add(item) + " ");
        }
        Console.WriteLine();

        int removes = int.Parse(Console.ReadLine());

        for (int i = 0; i < removes; i++)
        {
            Console.Write(addRemoveCollection.Remove() + " ");
        }
        Console.WriteLine();
        for (int i = 0; i < removes; i++)
        {
            Console.Write(myList.Remove() + " ");
        }
        Console.WriteLine();
    }
}

