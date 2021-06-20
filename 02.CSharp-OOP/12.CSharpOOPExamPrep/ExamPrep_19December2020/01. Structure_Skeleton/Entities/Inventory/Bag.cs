using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;
using WarCroft.Entities.Inventory;
using System.Linq;

namespace WarCroft.Entities.Inventory.Contracts
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private int load;
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Load
        {
            get
            {
                foreach(var item in items)
                {
                    load += item.Weight;
                }

                return this.load;
            }
        }

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public int Capacity
        {
            get => this.capacity;
            set => this.capacity = value;
        }

        public void AddItem(Item item)
        {
            if (this.load + item.Weight > this.capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = items.FirstOrDefault((i => i.GetType().Name == name));

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);
            return item;
        }
    }
}
