using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    private decimal workHoursPerDay;
            
    public decimal WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }


    public Worker(string firstName , string secondName ,decimal weekSalary , decimal workHoursPerDay) : base(firstName , secondName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(base.ToString());
        sb.AppendLine($"Week Salary: {this.weekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {this.CalculateSalary():f2}");
        return sb.ToString().Trim();
    }

    private decimal CalculateSalary()
    {
        decimal result = this.weekSalary / (5m * this.workHoursPerDay);
        return result;
    }
}

