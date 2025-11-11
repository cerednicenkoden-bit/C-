using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class AirConditioner : Device, IEnergyConsumer
    {
        public string DeviceName => Name ?? "Unnamed Air Conditioner";
        public int PowerConsumption { get; private set; } = 2000;

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} почав охолодження.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} зупинено.");
        }

        public double GetEnergyUsage(int hours)
        {
            if (!IsOn)
                return 0.0;

            return PowerConsumption * hours / 1000.0;
        }
    }
}
