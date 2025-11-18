using System;
using Restaurant.Core;
using Restaurant.Models;

class Program
{
    static void Main()
    {
        var manager = new RestaurantManager();

        
        manager.AddDish("Борщ", 120m, "Перше", isVegan: false);
        manager.AddDrink("Кава", 60m, "Напої", 200, isAlcoholic: false);
        manager.AddDrink("Сік апельсиновий", 70m, "Напої", 250, isAlcoholic: false);
        manager.AddDish("Салат Овочевий", 90m, "Салати", isVegan: true);

        // показати
        Console.WriteLine("--- МЕНЮ РЕСТОРАНУ ---");
        foreach (var item in manager.GetFullMenu())
        {
            Console.WriteLine($"{item.Id}. {item.GetInfo()}");
        }
        Console.WriteLine("-----------------------\n");

        // адреса
        var order = manager.CreateOrder(5);
        Console.WriteLine($"Створено нове замовлення для столика №{order.TableNumber}");

        // елемент за номером
        manager.AddMenuItemToOrder(order.Id, 1); // Борщ
        Console.WriteLine("Додано позицію: Борщ");
        manager.AddMenuItemToOrder(order.Id, 2); // Кава
        Console.WriteLine("Додано позицію: Кава");

        Console.WriteLine($"Поточна сума: {order.GetTotal()} грн\n");

        
        Console.WriteLine($"Статус замовлення: {order.Status}");
        manager.ChangeOrderStatus(order.Id, OrderStatus.InProgress);
        Console.WriteLine($"> Змінено статус: {order.Status}");
        manager.ChangeOrderStatus(order.Id, OrderStatus.Ready);
        Console.WriteLine($"> Змінено статус: {order.Status}");
        manager.ChangeOrderStatus(order.Id, OrderStatus.Paid);
        Console.WriteLine($"> Змінено статус: {order.Status}\n");

        
        Console.WriteLine("--- УСІ ЗАМОВЛЕННЯ ---");
        foreach (var o in manager.GetActiveOrders())
        {
            Console.WriteLine(o);
        }

        // пошук приклади
        Console.WriteLine();
        Console.WriteLine("Пошук у меню: 'Кава'");
        foreach (var r in manager.SearchMenuByName("Кава")) Console.WriteLine(r.GetInfo());

        Console.WriteLine();
        Console.WriteLine("Демонстрація upcast/downcast:");
        manager.DemonstrateUpcastDowncast();
    }
}
