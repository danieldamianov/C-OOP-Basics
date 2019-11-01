using System;
using System.Collections.Generic;
using System.Text;

public class AddCollection : List<string>, IAddCollection
{
    public new int Add(string item)
    {
        base.Add(item);
        return base.Count - 1;
    }
}

