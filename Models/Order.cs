using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Models
{
    public enum OrderStatus
    {
        New,
        InProgress,
        Ready,
        Paid
    }

    public class Order
    {
        private readonly List<MenuItem> _items = new();
        public Guid Id { get; } = Guid.NewGuid();
        public int TableNumber { get; }
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
        public OrderStatus Status { get; private set; } = OrderStatus.New;

        public Order(int tableNumber)
        {
            TableNumber = tableNumber;
        }

        public void AddItem(MenuItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public bool RemoveItem(int menuItemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == menuItemId);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }

        public decimal GetTotal()
        {
            return _items.Sum(i => i.Price);
        }

        public void SetStatus(OrderStatus status)
        {
            Status = status;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Столик: {TableNumber} | Статус: {Status} | Сума: {GetTotal()} грн";
        }
    }
}
