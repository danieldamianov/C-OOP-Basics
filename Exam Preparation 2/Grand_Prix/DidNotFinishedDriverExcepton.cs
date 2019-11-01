using System;
using System.Collections.Generic;
using System.Text;

public class DidNotFinishedDriverExcepton : ArgumentException
{
    public DidNotFinishedDriverExcepton(string message) : base(message)
    {

    }
}

