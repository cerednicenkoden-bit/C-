using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class Light : Device, IEnergyConsumer
    {
        public string DeviceName => Name ?? "Unnamed Light";
        public int PowerConsumption { get; private set; } = 60;

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} засвітилася.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} вимкнена.");
        }

        public double GetEnergyUsage(int hours)
        {
            if (!IsOn)
                return 0.0;

            return PowerConsumption * hours / 1000.0;
        }
    }
}
