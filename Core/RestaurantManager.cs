using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;

namespace Restaurant.Core
{
    public class RestaurantManager
    {
        private readonly List<MenuItem> _menu = new();
        private readonly List<Order> _orders = new();
        private int _nextMenuId = 1;

        // меню операції
        public Dish AddDish(string name, decimal price, string category, bool isVegan = false)
        {
            var dish = new Dish(_nextMenuId++, name, price, category, isVegan);
            _menu.Add(dish);
            return dish;
        }

        public Drink AddDrink(string name, decimal price, string category, int volumeMl, bool isAlcoholic = false)
        {
            var drink = new Drink(_nextMenuId++, name, price, category, volumeMl, isAlcoholic);
            _menu.Add(drink);
            return drink;
        }

        public IEnumerable<MenuItem> GetFullMenu() => _menu.AsReadOnly();

        public IEnumerable<MenuItem> SearchMenuByName(string query)
        {
            return _menu.Where(m => m.Name.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<MenuItem> SearchMenuByCategory(string category)
        {
            return _menu.Where(m => m.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        // замовлення 
        public Order CreateOrder(int tableNumber)
        {
            var order = new Order(tableNumber);
            _orders.Add(order);
            return order;
        }

        public bool AddMenuItemToOrder(Guid orderId, int menuItemId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            var item = _menu.FirstOrDefault(m => m.Id == menuItemId);
            if (order == null || item == null) return false;
            order.AddItem(item);
            return true;
        }

        public bool RemoveMenuItemFromOrder(Guid orderId, int menuItemId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return false;
            return order.RemoveItem(menuItemId);
        }

        public Order? FindOrder(Guid orderId) => _orders.FirstOrDefault(o => o.Id == orderId);

        public IEnumerable<Order> GetActiveOrders() => _orders.AsReadOnly();

        public bool ChangeOrderStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return false;
            order.SetStatus(newStatus);
            return true;
        }

        // приклади upcast/downcast
        public void DemonstrateUpcastDowncast()
        {
            MenuItem upcasted = new Dish(999, "Sample Dish", 10m, "Test", true); 
            if (upcasted is Dish downcasted)
            {
                Console.WriteLine($"Downcast succeeded. Dish is vegan: {downcasted.IsVegan}");
            }
        }
    }
}
