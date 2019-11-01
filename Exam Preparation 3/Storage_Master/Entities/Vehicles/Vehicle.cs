using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    abstract class Vehicle
    {
        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; }

        private List<Product> trunk;

        public IReadOnlyCollection<Product> Trunk // CHECK AGAIN STRUCTURE
        {
            get { return trunk.AsReadOnly(); }
        }


        public bool IsFull => this.trunk.Sum(pr => pr.Weight) >= this.Capacity; //CHECK ACCESS MODIFIER

        public bool IsEmpty => this.trunk.Count == 0; //CHECK ACCESS MODIFIER

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            Product productToRemove = this.trunk.Last();
            this.trunk.RemoveAt(this.trunk.Count - 1);
            return productToRemove;
        }
    }
}
