using System;
using System.Collections.Generic;
using System.Text;

public class AddRemoveCollection : List<string>, IAddRemoveCollection
{
    public string Remove()
    {
        string last = base[base.Count - 1];
        base.RemoveAt(base.Count - 1);
        return last;
    }

    public new int Add(string item)
    {
        base.Insert(0, item);
        return 0;
    }
}

