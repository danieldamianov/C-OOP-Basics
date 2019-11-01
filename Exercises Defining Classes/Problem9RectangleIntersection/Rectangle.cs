using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    public string Name { get; set; }

    public Point TopLeft { get; set; }

    public Point BottomRight { get; set; }

    public Rectangle(string name , double width , double height , double topLeftHoriz , double topLeftVert)
    {
        this.Name = name;
        this.TopLeft = new Point(topLeftHoriz, topLeftVert);
        this.BottomRight = new Point(topLeftHoriz + width , topLeftVert - height);
    }

    public bool IntersectsWith(Rectangle rectangle)
    {
        if (this.TopLeft.horizontal > rectangle.BottomRight.horizontal || rectangle.TopLeft.horizontal > this.BottomRight.horizontal)
            return false;

   
        if (this.TopLeft.vertical < rectangle.BottomRight.vertical || rectangle.TopLeft.vertical < this.BottomRight.vertical)
            return false;

        return true;
    }
}
