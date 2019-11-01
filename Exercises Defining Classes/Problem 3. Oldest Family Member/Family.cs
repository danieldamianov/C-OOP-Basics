using System;
using System.Collections.Generic;
using System.Text;

public class Family
{
    public List<Person> members;
    public void AddMember(Person member)
    {
        members.Add(member);
    }
    public Person GetOldestMember()
    {
        Person oldestMember = new Person("", -10000);
        foreach (var member in members)
        {
            if (member.Age > oldestMember.Age)
            {
                oldestMember.Name = member.Name;
                oldestMember.Age = member.Age;
            }
        }
        return oldestMember;
    }
    public Family()
    {
        this.members = new List<Person>();
    }
}
