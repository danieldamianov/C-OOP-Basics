using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        Family family = new Family();
        string namePattern = @"[a-zA-Z0-9]+\s[a-zA-Z0-9]+";
        string datePattern = @"\d{1,2}\/\d{1,2}\/\d{4}";
        string pattern1 = $@"({namePattern})\s-\s({namePattern})";
        string pattern2 = $@"({namePattern})\s-\s({datePattern})";
        string pattern3 = $@"({datePattern})\s-\s({namePattern})";
        string pattern4 = $@"({datePattern})\s-\s({datePattern})";
        string pattern5 = $@"({namePattern})\s({datePattern})";
        string mainPersonInput = Console.ReadLine();
        string input;
        List<Person> people = new List<Person>();
        List<string> connections = new List<string>();

        while ((input = Console.ReadLine()) != "End")
        {
            if (Regex.IsMatch(input , pattern5))
            {
                string name = Regex.Match(input, pattern5).Groups[1].Value;
                string date = Regex.Match(input, pattern5).Groups[2].Value;
                people.Add(new Person(name, date));
            }
            else
            {
                connections.Add(input);
            }
        }

        family.MainPerson = people.FirstOrDefault(x => (x.Name == mainPersonInput) || x.DateOfBirth == mainPersonInput);
        
        foreach (var command in connections)
        {
            var match1 = Regex.Match(command, pattern1);
            var match2 = Regex.Match(command, pattern2);
            var match3 = Regex.Match(command, pattern3);
            var match4 = Regex.Match(command, pattern4);
            
            if (match1.Success)
            {
                string olderName = match1.Groups[1].Value;
                string youngerName = match1.Groups[2].Value;

                if (olderName == family.MainPerson.Name)
                {
                    family.Children.Add(people.FirstOrDefault(x => x.Name == youngerName));
                }
                else if (youngerName == family.MainPerson.Name)
                {
                    family.Parents.Add(people.FirstOrDefault(x => x.Name == olderName));
                }
            }
            else if (match2.Success)
            {
                string olderName = match2.Groups[1].Value;
                string youngerDate = match2.Groups[2].Value;

                if (olderName == family.MainPerson.Name)
                {
                    family.Children.Add(people.FirstOrDefault(x => x.DateOfBirth == youngerDate));
                }
                else if (youngerDate == family.MainPerson.DateOfBirth)
                {
                    family.Parents.Add(people.FirstOrDefault(x => x.Name == olderName));
                }
            }
            else if (match3.Success)
            {
                string olderDate = match3.Groups[1].Value;
                string youngerName = match3.Groups[2].Value;

                if (olderDate == family.MainPerson.DateOfBirth)
                {
                    family.Children.Add(people.FirstOrDefault(x => x.Name == youngerName));
                }
                else if (youngerName == family.MainPerson.Name)
                {
                    family.Parents.Add(people.FirstOrDefault(x => x.DateOfBirth == olderDate));
                }
            }
            else if (match4.Success)
            {
                string olderDate = match4.Groups[1].Value;
                string youngerDate = match4.Groups[2].Value;
                if (olderDate == family.MainPerson.DateOfBirth)
                {
                    family.Children.Add(people.FirstOrDefault(x => x.DateOfBirth == youngerDate));
                }
                else if (youngerDate == family.MainPerson.DateOfBirth)
                {
                    family.Parents.Add(people.FirstOrDefault(x => x.DateOfBirth == olderDate));
                }
            }
        }
        Console.WriteLine(family);
    }
}
