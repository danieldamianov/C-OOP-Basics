using System;
using System.Collections.Generic;
using System.Text;

public abstract class Worker
{
    public string id { get; private set; }

    protected Worker(string Id)
    {
        this.id = Id;
    }
}

