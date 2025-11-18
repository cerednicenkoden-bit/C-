using System;

namespace Restaurant.Models
{
    {
        public int Id { get; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public string Category { get; protected set; }

        protected MenuItem(int id, string name, decimal price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public abstract string GetInfo();
    }
}
