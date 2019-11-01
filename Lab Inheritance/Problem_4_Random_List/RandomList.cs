using System;
using System.Collections.Generic;
using System.Text;

public class RandomList : List<string>
{
    public string RandomString()
    {
        if (this.Count == 0)
        {
            return null;
        }
        else
        {
            Random random = new Random();
            int index = random.Next(0, this.Count - 1);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
    } 
}
