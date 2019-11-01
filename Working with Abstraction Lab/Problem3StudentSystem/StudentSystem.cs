using System;
using System.Collections.Generic;
using System.Text;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public Dictionary<string, Student> Repo
    {
        get { return repo; }
        private set { repo = value; }
    }

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    public void Create(string name , int age , double grade)
    {
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            Repo[name] = student;
        }
    }

    public void Show(string name)
    {
        if (Repo.ContainsKey(name))
        {
            Console.WriteLine(Repo[name]);
        }
    }
}
