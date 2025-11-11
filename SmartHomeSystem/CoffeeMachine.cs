using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class CoffeeMachine : Device, IEnergyConsumer
    {
        public string DeviceName => Name ?? "Unnamed Coffee Machine";
        public int PowerConsumption { get; private set; } = 1000;

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} почала готувати каву.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} завершила роботу.");
        }

        public double GetEnergyUsage(int hours)
        {
            if (!IsOn)
                return 0.0;

            return PowerConsumption * hours / 1000.0;
        }
    }
}
