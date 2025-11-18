using System;

namespace Restaurant.Models
{
    public class Dish : MenuItem
    {
        public bool IsVegan { get; private set; }

        public Dish(int id, string name, decimal price, string category, bool isVegan = false)
            : base(id, name, price, category)
        {
            IsVegan = isVegan;
        }

        public override string GetInfo()
        {
            return $"{Name} ({Category}) - {Price} грн{(IsVegan ? " - веган" : string.Empty)}";
        }
    }
}
