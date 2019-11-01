using System;

namespace Problem3StudentSystem
{
    class Program
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            string input;

            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] args = input.Split();
                if (args[0] == "Create")
                {
                    studentSystem.Create(args[1],int.Parse(args[2]),double.Parse(args[3]));
                }
                else if(args[0] == "Show")
                {
                    studentSystem.Show(args[1]);
                }
            }
        }
    }
}
