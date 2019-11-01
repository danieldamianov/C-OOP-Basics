using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class DateModifier
{
    public DateTime date1 { get; set; }
    public DateTime date2 { get; set; }

    public int diff
    {
        get
        {
            return Math.Abs(this.date1.Subtract(this.date2).Days);
        }
        set
        {

        }
    }

    public DateModifier(string date1String ,string date2String)
    {
        this.date1 = DateTime.ParseExact(date1String, "yyyy MM dd", CultureInfo.CurrentCulture);
        this.date2 = DateTime.ParseExact(date2String, "yyyy MM dd", CultureInfo.CurrentCulture);
    }
}