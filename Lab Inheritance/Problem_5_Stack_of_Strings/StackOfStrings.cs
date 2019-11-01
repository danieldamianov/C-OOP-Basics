using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StackOfStrings
{
    private List<string> list;
    public bool IsEmpty()
    {
        return this.list.Count == 0;
    }

    public void Push(string str)
    {
        this.list.Add(str);
    }

    public string Peek()
    {
        return this.list.Last();
    }

    public string Pop()
    {
        string str = this.list.Last();
        this.list.RemoveAt(this.list.Count - 1);
        return str;
    }
}
