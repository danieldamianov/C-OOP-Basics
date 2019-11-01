using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Trim().Length == 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public decimal CurrentMoney => money - this.products.Sum(x => x.Cost);

    private List<Product> products;

    public List<Product> Products
    {
        get { return products; }
        private set { products = value; }
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }

    public override string ToString()
    {
        string productsStr = string.Join(", ", this.products.Select(x => x.Name));
        if (this.products.Count == 0)
        {
            productsStr = "Nothing bought";
        }
        return $"{this.name} - {productsStr}";
    }
}

