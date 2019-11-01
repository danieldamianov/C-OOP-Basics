using System;
using System.Collections.Generic;
using System.Text;

public interface IBuyer : INamable
{
    int Food { get; }
    void BuyFood();
}

