using System;
using System.Collections.Generic;
using System.Text;

class PriceCalculator
{
    public static string GetPrice(string command)
    {
        string[] commandSplit = command.Split();
        decimal pricePerNight = decimal.Parse(commandSplit[0]);
        int nightsCount = int.Parse(commandSplit[1]);
        int season = (int)Enum.Parse<SeasonsEnum>(commandSplit[2]);
        int discount = (int)DiscountsEnum.None;
        if (commandSplit.Length > 3)
        {
            discount = (int)Enum.Parse<DiscountsEnum>(commandSplit[3]);
        }
        decimal discountCoef = (decimal)(100 - discount) / 100m;
        decimal price = nightsCount * pricePerNight * season * discountCoef;
        return price.ToString("f2");
    }
}
