public class Company
{
    public string CompanyName { get; set; }

    public string Department { get; set; }

    public double Salary { get; set; }

    public Company(string companyName , string department , double salary)
    {
        this.CompanyName = companyName;
        this.Department = department;
        this.Salary = salary;
    }

    public Company()
    {
    }

    public override string ToString()
    {
        if (this.Salary != 0)
        {
            return $"{this.CompanyName} {this.Department} {this.Salary:f2}";
        }
        else
        {
            return null;
        }
    }
}