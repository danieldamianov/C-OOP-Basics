using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    public Point TopLeft { get; set; }

    public Point BottomRight { get; set; }

    public bool Contains(Point point)
    {
        if (point.Horizontal >= TopLeft.Horizontal && point.Horizontal <= BottomRight.Horizontal
            && point.Vertical <= BottomRight.Vertical && point.Vertical >= TopLeft.Vertical)
        {
            return true;
        }
        return false;
    }
}
