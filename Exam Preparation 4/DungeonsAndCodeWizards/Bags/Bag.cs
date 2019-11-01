using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag
    {
        private const int defaultCapacity = 100;

        private List<Item> items;

        protected Bag(int capacity)
        {
            items = new List<Item>();
            this.Capacity = capacity;
        }

        public int Capacity { get; }

        public int Load => this.items.Sum(item => item.Weight);

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (this.items.Exists(it => it.GetType().Name == name) == false) // CHECK LATER AGAIN !!!!!!
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            // TODO :: CHECK IF ITEM EXISTS IN THE BAG !!!
            Item item = this.items.Last(it => it.GetType().Name == name);
            this.items.Remove(this.items.Last(it => it.GetType().Name == name));
            return item;
        }
    }
}
