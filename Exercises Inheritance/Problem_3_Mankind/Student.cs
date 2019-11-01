using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;
    private const string numberPattern = @"[0-9a-zA-Z]{5,10}";

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10 || (Regex.IsMatch(value , numberPattern) == false))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName , string lastName , string facultyNumber) : base(firstName , lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(base.ToString());
        sb.AppendLine($"Faculty number: {this.FacultyNumber}");
        return sb.ToString().Trim();
    }
}

