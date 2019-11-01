using System;
using System.Collections.Generic;
using System.Text;

public class MyList : List<string>, IMyList
{
    public int Used => base.Count;

    public string Remove()
    {
        string last = base[0];
        base.RemoveAt(0);
        return last;
    }

    public new int Add(string item)
    {
        base.Insert(0, item);
        return 0;
    }
}

