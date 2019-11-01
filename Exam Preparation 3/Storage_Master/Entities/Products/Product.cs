using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    abstract class Product
    {
        private double price;

        protected Product(double price, double weight) //MAY THROW EXCEPTION!!!
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get { return price; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                price = value;
            }
        }

        public double Weight { get; }

    }
}
