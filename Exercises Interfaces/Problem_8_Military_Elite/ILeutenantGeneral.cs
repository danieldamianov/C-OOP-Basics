using System;
using System.Collections.Generic;
using System.Text;

public interface ILeutenantGeneral : IPrivate
{
    IReadOnlyCollection<Private> Privates { get; }

    void AddPrivate(Private privateObj);
}

